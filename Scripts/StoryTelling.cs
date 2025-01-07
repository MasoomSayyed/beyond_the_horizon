using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class StoryTelling : MonoBehaviour
{
    private TextMeshProUGUI panelText;
    private string text;
    [SerializeField] private float typingSpeed = 30f;
    private UnityEngine.UI.Button playButton;
    void Start()
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
        //playButton.gameObject.SetActive(true);
    }

    IEnumerator TypeStory()
    {
        foreach (char alphabet in text)
        {
            panelText.text += alphabet;
            yield return new WaitForSeconds(1 / typingSpeed);
        }
        playButton.gameObject.SetActive(true);
    }
}
