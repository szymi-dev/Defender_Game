using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public int score;

    private void Start()
    {
        scoreText.text = score.ToString();

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();

    }

}
