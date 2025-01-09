using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableRock : MonoBehaviour
{
    private int damage = 40;
    [SerializeField] private AudioClip audioRockbreakClip;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && MovementSystemDifferentModes.Instance.CanPropel())
        {
            AudioSource.PlayClipAtPoint(audioRockbreakClip, transform.position);
            HealthBar.Instance.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

