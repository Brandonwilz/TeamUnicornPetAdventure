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

    void Update()
    {
        if (Input.GetKeyDown(JumpUpKey) && canMove && transform.position.y < 0)
        {
            canMove = false;
            playerBase.PlayerJumpDirection = new Vector3(0, 1, 0);
            JumpUp = true;
            StartCoroutine(MoveCooldown());
        }
        if (Input.GetKeyDown(JumpDownKey) && canMove)
        {
            canMove = false;
            JumpDown = true;
            StartCoroutine(MoveCooldown());
        }
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
