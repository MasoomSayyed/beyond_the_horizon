using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isStoryCompleted = false;
    public bool isEndSceneCompleted = false;

    //Pause Screen
    public GameObject pauseScreen;
    public string gameManagerInitialScene;
    public float soundEffectsVolume = 1; // SoundEffects volume


    private void Awake()
    {
        gameManagerInitialScene = SceneManager.GetActiveScene().name;
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
        Debug.Log("Paused");
    }

    public void ResumeGame()
    {
        //hide pause screen
        pauseScreen.SetActive(false);
         Time.timeScale = 1;
    }

    public void PlayAudioClipAtPoint(AudioClip audioClip, Vector3 position)
    {
        if (gameManagerInitialScene == "MainMenu")
        {
            AudioSource.PlayClipAtPoint(audioClip, position, soundEffectsVolume);
        }
        else
        {
            AudioSource.PlayClipAtPoint(audioClip, position);
        }
    }
}
