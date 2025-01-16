using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapSound : MonoBehaviour
{
    [SerializeField] private AudioClip bumpAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (collision.gameObject.tag == "Player" && gameManager != null)
        {
            gameManager.PlayAudioClipAtPoint(bumpAudio, transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (collision.gameObject.tag == "Player" && gameManager != null)
        {
            gameManager.PlayAudioClipAtPoint(bumpAudio, transform.position);
        }
    }
}