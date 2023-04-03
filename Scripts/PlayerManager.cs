using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
   
    public static int score;
    public static int highScore;

    [SerializeField] Score highScoreData;
    [SerializeField] TextMeshProUGUI recentScore;
    [SerializeField] GameObject quadRun;
    [SerializeField] Camera cameraPos;

    public static bool isGamePaused;   

    [SerializeField] GameObject mainMenu; 

    void Start()
    {
        score = 0;
        Time.timeScale = 1;
        gameOver = isGameStarted = isGamePaused = false;
        highScore = highScoreData.score;
     
    }

    void Update()
    {
        
        //Game Over
        if (gameOver)
        {
            Time.timeScale = 0;           
            if (score > highScoreData.score)
            {
                highScoreData.score = score;
                FindObjectOfType<AudioManager>().PlaySound("GameOver");
                highScore = score;
                
            }
 

            gameOverPanel.SetActive(true);
            
        }


        //Start Game
        recentScore.text = "Score: " + score.ToString();
        
    }

    public void StartGame()
    {
        isGameStarted = true;

    }

    public void TryAgain()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}