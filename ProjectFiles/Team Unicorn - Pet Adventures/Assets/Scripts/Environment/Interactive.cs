using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private bool DamageToPlayer = false;
    [SerializeField] private float SpeedChange;

    [HideInInspector] public Environment environment;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Movement>())
        {
            Player_Movement player = collision.gameObject.GetComponent<Player_Movement>();

            if (DamageToPlayer) player.DamageThePayer();
            else environment.SpeedChange(SpeedChange);
        }
    }
}
