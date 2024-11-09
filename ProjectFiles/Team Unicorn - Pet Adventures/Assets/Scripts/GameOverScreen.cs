using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text ScoreText;

    private void Start()
    {
        int rNum = Random.Range((int)0, (int)1000);
        ScoreText.text = "For you " + rNum + " :)";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

}
