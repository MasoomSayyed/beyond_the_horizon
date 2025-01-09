using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStoryCompleted = false;
    public bool isEndSceneCompleted = false;

    //Pause Screen
    public GameObject pauseScreen;


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
        Debug.Log("working");
    }

    public void ResumeGame()
    {
        //hide pause screen
        pauseScreen.SetActive(false);
         Time.timeScale = 1;
    }
}
