using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaveSplashSound : MonoBehaviour
{
    private float damage = 1f;
    [SerializeField] private AudioClip audioSplashClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioSplashClip, transform.position);
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioSplashClip, transform.position);
        }
    }
}
