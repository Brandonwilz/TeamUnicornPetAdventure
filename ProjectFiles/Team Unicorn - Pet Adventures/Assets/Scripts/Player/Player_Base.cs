using UnityEngine;

public class Player_Base : MonoBehaviour
{
    public float PlayerJumpForce = 5;
    public float PlayerSpeed = 10f;
    public float PlayerMoveX = 1f;
    public float PlayerMoveY = 0f;
    public float PlayerGravityScale = 30f;
    public float PlayerMinGravityScale = 10f;
    public float ExtraHeightOffset = 0.1f;
    public Vector3 PlayerMoveDirection = new Vector3(1, 0, 0);
    public int PlayerHp = 2;
    public bool IsGrounded = true;
    public bool GoingThroughPlatform = false;
    public string PlatformTag;
    public LayerMask PlatformLayerMask;
    public Rigidbody2D Rb;
}
