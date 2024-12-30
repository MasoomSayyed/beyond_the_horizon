using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

    }

    public void StarGame()
    {
        SceneManager.LoadScene("Story");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("ExitScene");
    }

    public void Play()
    {
        SceneManager.LoadScene("Test Area");
    }
}
