using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private Player_Base playerBase;
    [SerializeField] private Player_Input playerInput;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Collider2D PlayerCollider;
    [SerializeField] private CinemachineVirtualCamera cmVrCam;
    [SerializeField] private Environment environment;

    private void FixedUpdate()
    {
        if (playerInput.JumpUp) Jump();
        if (playerInput.JumpDown) GoDown();
    }


    public void DamageThePayer()
    {
        playerBase.PlayerHp--;
        CheckPlayerHp();
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
        yield return new WaitForSeconds(.25f);
        anim.SetBool("JumpDown", false);
        Physics2D.IgnoreCollision(PlayerCollider, platformCollider, false);
    }

    private void Jump()
    {
        playerInput.JumpUp = false;
        rb.velocity = playerBase.PlayerJumpDirection * playerBase.PlayerJumpForce;
        anim.SetBool("JumpUp", true);
        StartCoroutine(JumpingTime());
    }

    IEnumerator JumpingTime()
    {
        yield return new WaitForSeconds(.25f);
        
        anim.SetBool("JumpUp", false);
        playerBase.PlayerJumpDirection = new Vector3(0, 0, 0);
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

}
