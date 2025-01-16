using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBall : MonoBehaviour
{
    private int Heal = 30;
    [SerializeField] private AudioClip healItemAudio;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(healItemAudio, transform.position);
            HealthBar.Instance.RestoreHealth(Heal);
            Destroy(gameObject);
        }
    }
}
