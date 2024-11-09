using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] private GameObject MovePoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChunkElementsSpawnSystem>())
        {
            collision.gameObject.transform.position = new Vector3(MovePoint.transform.position.x, 0, 0);
            collision.gameObject.GetComponent<ChunkElementsSpawnSystem>().SpawnElementsAgain();
        }
    }
}
