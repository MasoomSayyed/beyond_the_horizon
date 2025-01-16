using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMine : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    private int damage = 10;
    [SerializeField] private AudioClip mineBlastAudio;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (collision.gameObject.tag == "Player" && gameManager != null)
        {
            gameManager.PlayAudioClipAtPoint(mineBlastAudio, transform.position);
            HealthBar.Instance.TakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
