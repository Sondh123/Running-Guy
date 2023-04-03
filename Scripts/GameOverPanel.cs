using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    private void Start()
    {
        
    }
    private void Update()
    {
        scoreText.text = "Score: " + PlayerManager.score;
        highScoreText.text = "Best: " + PlayerManager.highScore;


    }
}
