using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int passiveScoreIncrement = 100;
    [SerializeField] float passiveScoreRate = 2f;

    int score = 0;
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        IncrementScorePassively();
    }

    private void IncrementScore()
    {
        score += passiveScoreIncrement;
        scoreText.text = score.ToString();
    }

    private void IncrementScorePassively()
    {
        InvokeRepeating("IncrementScore", passiveScoreRate, passiveScoreRate);
    }

    public void IncrementScorePetHit(int scorePerHit)
    {
        score += scorePerHit;
        scoreText.text = score.ToString();
    }
}
