using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishesCollision : MonoBehaviour
{
    private CapsuleCollider2D fish;
    public bool hasCollided = false;
    void Start()
    {
        fish = GetComponent<CapsuleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Environment") || collision.CompareTag("BreakableRock"))
        {
            hasCollided = true;
        }
    }
}