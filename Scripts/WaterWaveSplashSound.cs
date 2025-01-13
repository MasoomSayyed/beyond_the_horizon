using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaveSplashSound : MonoBehaviour
{
    [SerializeField] private AudioClip audioSplashClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        GameManager[] gameManager = FindObjectsByType<GameManager>(FindObjectsSortMode.None);
        Debug.Log(gameManager.Length);
        if (collision.gameObject.tag == "Player" )
        {
            if (gameManager != null)
            {
                AudioSource.PlayClipAtPoint(audioSplashClip, transform.position, gameManager[0].soundEffectsVolume);
            }
            else
            {
                AudioSource.PlayClipAtPoint(audioSplashClip, transform.position);
            }
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (collision.gameObject.tag == "Player" && gameManager != null)
        {
            //AudioSource.PlayClipAtPoint(audioSplashClip, transform.position);
        }
    }
}
