using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] List<GameObject> Chunks = new List<GameObject>();

    public GameObject GameOverScreen;
    public float chunkMoveSpeed = 1f;

    public void SpeedChange(float value)
    {
        chunkMoveSpeed += value;
    }

    public void GameOver()
    {
        chunkMoveSpeed = 0f;
        GameOverScreen.SetActive(true);
    }
}
