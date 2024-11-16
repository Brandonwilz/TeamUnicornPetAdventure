using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] List<GameObject> Chunks = new List<GameObject>();

    public GameObject GameOverScreen;

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
