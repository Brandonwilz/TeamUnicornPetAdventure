using System.Collections;
using UnityEngine;

public class BackgroundSpriteMotion : MonoBehaviour
{
    static readonly float LoopDistance = 19.2f;

    [SerializeField] private Transform CameraTransform;

    private Vector3 Position = Vector3.zero;

    private void Start() {
        Position = transform.position;
    }

    private void Update() {
        if (transform.position.x <= CameraTransform.position.x - LoopDistance * 2f) {
            Position = transform.position;
            Position.x += LoopDistance * 4f;
            transform.position = Position;
        }
    }
}
