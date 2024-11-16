using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    [SerializeField] private Player_Base playerBase;
    [HideInInspector] public GameObject currentOneWayPlatform;

    public KeyCode JumpUpKey = KeyCode.W;
    public KeyCode JumpDownKey = KeyCode.S;

    public bool JumpDown = false;
    public bool JumpUp = false;

    private bool canMove = true;
    private Coroutine jumpCoroutine;

    void Update()
    {
        if (Input.GetKeyDown(JumpUpKey) && playerBase.IsGrounded)
        {
            canMove = false;
            playerBase.PlayerMoveY = playerBase.PlayerJumpForce;
            JumpUp = true;
            StartCoroutine(MoveCooldown());
        }
        if ((Input.GetKeyUp(JumpUpKey)))
        {
            playerBase.PlayerMoveY = 0f;
        }
        if (Input.GetKeyDown(JumpDownKey) && canMove)
        {
            canMove = false;
            JumpDown = true;
            StartCoroutine(MoveCooldown());
        }

        playerBase.PlayerMoveDirection = new Vector3(playerBase.PlayerMoveX, playerBase.PlayerMoveY, 0f);
    }

    IEnumerator MoveCooldown()
    {
        yield return new WaitForSeconds(.40f);
        canMove = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerBase.PlatformTag))
        {
            if (!collision.gameObject.GetComponent<BottomGround>()) currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerBase.PlatformTag))
        {
           // currentOneWayPlatform = null;
        }
    }
}
