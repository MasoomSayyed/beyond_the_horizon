using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaveSplashSound : MonoBehaviour
{
    [SerializeField] private AudioClip audioSplashClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (collision.gameObject.tag == "Player" )
        {
            gameManager.PlayAudioClipAtPoint(audioSplashClip, transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (collision.gameObject.tag == "Player" && gameManager != null)
        {
            gameManager.PlayAudioClipAtPoint(audioSplashClip, transform.position);
        }
    }
}
