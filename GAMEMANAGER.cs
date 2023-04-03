using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GAMEMANAGER : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        FindObjectOfType<AudioManager>().PlaySound("SoundTrack");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PlayerManager.isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        pausePanel.SetActive(true);
        FindObjectOfType<AudioManager>().PlaySound("Pause");
        Time.timeScale = 0f;
        PlayerManager.isGamePaused = true;
    }
    private void Resume()
    {
        pausePanel.SetActive(false);
        FindObjectOfType<AudioManager>().PlaySound("UnPause");
        Time.timeScale = 1f;
        PlayerManager.isGamePaused = false;
        
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
