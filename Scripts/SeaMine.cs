using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMine : MonoBehaviour
{
    private int damage = 10;
    [SerializeField] private AudioClip mineBlastAudio;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(mineBlastAudio, transform.position);
            HealthBar.Instance.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
