using System.Collections;
using UnityEngine;

public class BackgroundMotion : MonoBehaviour
{
    [SerializeField] Transform CameraTransform = null;
    [SerializeField] float PositionFactor = 0.95f;

    private Vector3 Position = Vector3.zero;

    private void Start() {
        Position = transform.position;
        if(PositionFactor > 1f) {
            PositionFactor = 1f;
        }
    }

    private void Update() {
        Position.x = CameraTransform.position.x * PositionFactor;
        transform.position = Position;
    }
}
