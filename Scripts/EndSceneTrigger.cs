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
        // foreach (GameObject gameobject in gameObjects)
        // {
        //  Destroy(gameobject);
        // }
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
