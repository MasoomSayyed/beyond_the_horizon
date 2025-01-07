using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StarGame()
    {
        SceneManager.LoadScene("Story");
    }

    public void EndGame()
    {
        //Application.Quit();
        SceneManager.LoadScene("EndScene");
    }

    public void Play()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
}
