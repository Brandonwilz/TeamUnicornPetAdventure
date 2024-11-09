using System.Collections;
using UnityEngine;

public class MoveCycle : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 0f;
    [SerializeField] private float MoveTime = 1f;
    [SerializeField] private bool IsNextMoveRight = true;

    private Rigidbody2D rb;

    private bool IsMovingRight = false;
    private bool IsMovingLeft = false;

    private Vector3 MoveVector = Vector3.zero;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (IsMovingRight) {
            MoveVector.x = MoveSpeed;
        }
        else if (IsMovingLeft) {
            MoveVector.x = -MoveSpeed;
        }
        else if (IsNextMoveRight) {
            IsMovingRight = true;
            StartCoroutine(MoveTimer(MoveTime));
        }
        else if (!IsNextMoveRight){
            IsMovingLeft = true;
            StartCoroutine(MoveTimer(MoveTime));
        }
        else {
            MoveVector = Vector3.zero;
        }

        rb.velocity = MoveVector;
    }

    private IEnumerator MoveTimer(float time) {
        yield return new WaitForSeconds(time);
        IsMovingRight = false;
        IsMovingLeft = false;
        IsNextMoveRight = !IsNextMoveRight;
    }
}
