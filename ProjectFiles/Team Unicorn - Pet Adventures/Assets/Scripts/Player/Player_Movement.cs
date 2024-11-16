using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private Player_Base playerBase;
    [SerializeField] private Player_Input playerInput;
    [SerializeField] private Animator anim;
    [SerializeField] private Collider2D PlayerCollider;
    [SerializeField] private CinemachineVirtualCamera cmVrCam;
    [SerializeField] private Environment environment;
    [SerializeField] private CircleCollider2D circleCollider2D;

    private void Update()
    {
        CheckIsGrounded();
    }

    private void FixedUpdate()
    {
        if (playerBase.IsGrounded) playerBase.Rb.gravityScale = playerBase.PlayerMinGravityScale;
        else playerBase.Rb.gravityScale = playerBase.PlayerGravityScale;

        playerBase.Rb.velocity = playerBase.PlayerMoveDirection * playerBase.PlayerSpeed;

        if (playerInput.JumpUp) Jump();
        if (playerInput.JumpDown) GoDown();
    }


    public void DamageThePayer()
    {
        playerBase.PlayerHp--;
        CheckPlayerHp();
    }

    public void SpeedChangePlayer(float _percentage)
    {
        Mathf.Clamp(playerBase.PlayerSpeed += (playerBase.PlayerSpeed / 100) * _percentage, 100f, 500f);
    }

    private void GoDown()
    {
        playerInput.JumpDown = false;
        anim.SetBool("JumpDown", true);
        StartCoroutine(JumpingDown());
    }

    IEnumerator JumpingDown()
    {
        BoxCollider2D platformCollider = playerInput.currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(PlayerCollider, platformCollider);
        playerBase.GoingThroughPlatform = true;
        yield return new WaitForSeconds(.4f);
        playerBase.GoingThroughPlatform = false;
        anim.SetBool("JumpDown", false);
        Physics2D.IgnoreCollision(PlayerCollider, platformCollider, false);
    }

    private void Jump()
    {
        playerInput.JumpUp = false;
        anim.SetBool("JumpUp", true);
        StartCoroutine(JumpingTime());
    }

    IEnumerator JumpingTime()
    {
        yield return new WaitForSeconds(.5f);
        
        anim.SetBool("JumpUp", false);
        playerBase.PlayerMoveY = 0f;
    }

    private void CheckPlayerHp()
    {
        if (playerBase.PlayerHp > 0) Debug.Log("Walk it off!");
        else EndGame();
    }

    private void EndGame()
    {
        Debug.Log("You dead...");
        anim.SetBool("GameOver", true);
        environment.GameOver();
        StartCoroutine(GameOverAnim());
    }
    IEnumerator GameOverAnim()
    {
        yield return new WaitForSeconds(.25f);

        anim.SetBool("GameOver", false);
    }

    private void CheckIsGrounded()
    {
        if (Physics2D.CircleCast(circleCollider2D.bounds.center,circleCollider2D.radius, Vector2.down,
            circleCollider2D.bounds.extents.y + playerBase.ExtraHeightOffset, playerBase.PlatformLayerMask) && !playerBase.GoingThroughPlatform)
        {
            playerBase.IsGrounded = true;

            if (Physics2D.Raycast(circleCollider2D.bounds.center, Vector2.right,
            circleCollider2D.bounds.extents.y + 1f, playerBase.PlatformLayerMask))
            {
                playerBase.Rb.gravityScale = 0f;
            }
            else
            {
                playerBase.Rb.gravityScale = playerBase.PlayerMinGravityScale;
            }
        }
        else
        {
            playerBase.IsGrounded = false;
            playerBase.Rb.gravityScale = playerBase.PlayerGravityScale;
        }
    }
}
