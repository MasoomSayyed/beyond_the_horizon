using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneTrigger : MonoBehaviour
{
    // private GameObject[] gameObjects;
    // private void Awake()
    // {
    //     gameObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
    // }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        // foreach (GameObject gameobject in gameObjects)
        // {
        //  Destroy(gameobject);
        // }
        if (collision.CompareTag("Player") && currentSceneName == "TutorialScene")
        {

            SceneManager.LoadScene("Level 1");
        }
        else if (collision.CompareTag("Player") && currentSceneName == "Level 1")
        {

            SceneManager.LoadScene("EndScene");
        }
    }
}
