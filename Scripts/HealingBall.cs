using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBall : MonoBehaviour
{
    private int Heal = 30;
    [SerializeField] private AudioClip healItemAudio;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (collision.gameObject.tag == "Player" && gameManager != null)
        {
            gameManager.PlayAudioClipAtPoint(healItemAudio, transform.position);
            HealthBar.Instance.RestoreHealth(Heal);
            Destroy(gameObject);
        }
    }
}
