using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStoryCompleted = false;
    public bool isEndSceneCompleted = false;

    // Game Over
    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameOverHighScoreText;

    //Pause Screen
    public GameObject pauseScreen;
    public TextMeshProUGUI pauseScoreText;
    public TextMeshProUGUI pauseHighScoreText;


    private void Awake()
    {
        GameObject[] gameManagers = GameObject.FindGameObjectsWithTag("GameController");
        if (gameManagers.Length > 1)
        {
            Destroy(gameManagers[1]);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PauseScreen()
    {
        //freeze screen and display pause screen
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        //hide pause screen
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        if (playerScore > savedHighScore)
        {
            savedHighScore = playerScore;
            PlayerPrefs.SetInt("HighScore", savedHighScore); // Save new high score
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);

        // Check if we need to update the saved high score
        if (playerScore > savedHighScore)
        {
            savedHighScore = playerScore;
            PlayerPrefs.SetInt("HighScore", savedHighScore); // Save new high score
        }
    }
}
