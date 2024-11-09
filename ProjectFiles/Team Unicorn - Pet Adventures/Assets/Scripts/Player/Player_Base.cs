using UnityEngine;

public class Player_Base : MonoBehaviour
{
    public float PlayerJumpForce = 10;
    public float PlayerSpeed = 10f;
    public Vector3 PlayerMoveDirection = new Vector3(1, 0, 0);
    public Vector3 PlayerJumpDirection = new Vector3(0, 0, 0);
    public int PlayerHp = 2;
    public bool IsGoingBack = false;
    public string PlatformTag;
}
