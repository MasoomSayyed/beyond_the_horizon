using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThunderClouds : MonoBehaviour
{
    private float damage = 1f;
    [SerializeField] private AudioClip audioThunderClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioThunderClip, transform.position);
            HealthBar.Instance.TakeDamage(damage);
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioThunderClip, transform.position);
        }
    }

}

