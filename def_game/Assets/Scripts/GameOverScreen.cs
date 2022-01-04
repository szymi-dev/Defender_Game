using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        scoreText.text = "SCORE " + ScoreManager.instance.score.ToString();
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Menubtn()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
