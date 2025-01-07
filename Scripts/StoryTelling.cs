using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StoryTelling : MonoBehaviour
{
    private TextMeshProUGUI panelText;
    private string text;
    [SerializeField] private float typingSpeed = 30f;
    private UnityEngine.UI.Button playButton;
    private GameManager gameManager;
    private string scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
        if (scene == "EndScene")
        {
            if (!gameManager.isEndSceneCompleted)
            {
                WriteMessage();
            }
        }
        else
        {
            if (!gameManager.isStoryCompleted)
            {
                WriteMessage();
            }
        }
    }

    private void WriteMessage()
    {
        playButton = GetComponentInChildren<UnityEngine.UI.Button>();
        playButton.gameObject.SetActive(false);
        panelText = GetComponent<TextMeshProUGUI>();
        if (panelText == null)
        {
            Debug.LogError("Text component not found!");
        }
        else
        {
            text = panelText.text;
            panelText.text = "";
        }
        StartCoroutine(TypeStory());
    }

    IEnumerator TypeStory()
    {
        foreach (char alphabet in text)
        {
            panelText.text += alphabet;
            yield return new WaitForSeconds(1 / typingSpeed);
        }
        playButton.gameObject.SetActive(true);
        if (scene == "EndScene")
        {
            gameManager.isEndSceneCompleted = true;
        }
        else
        {
            gameManager.isStoryCompleted = true;
        }
    }
}
