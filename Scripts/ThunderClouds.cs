using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThunderClouds : MonoBehaviour
{
    public static ThunderClouds Instance;
    public event EventHandler OnCloudEntered;
    [SerializeField] AudioClip audioThunderClip;

    private float damage = 1f;

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (collision.gameObject.tag == "Player" && gameManager != null)
        {
            gameManager.PlayAudioClipAtPoint(audioThunderClip, transform.position);
            HealthBar.Instance.TakeDamage(damage);
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (collision.gameObject.tag == "Player" && gameManager != null)
        {
            gameManager.PlayAudioClipAtPoint(audioThunderClip, transform.position);
        }
    }

}

