using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RecordText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscoreText;
    [SerializeField] Score score;
    // Update is called once per frame
    void Update()
    {
        highscoreText.text = "Best: " + score.score.ToString();
    }
}
