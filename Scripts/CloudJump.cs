using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudJump : MonoBehaviour
{
    private Vector3 cloudPosition;
    private Vector2 jumpDirection;
    private float jumpAngleInRad;
    [SerializeField] private float verticalCloudDisplacement = 2f;
    [SerializeField] private float jumpAngle = 30f;
    [SerializeField] private float jumpingForce = 3f;
    [SerializeField] private float delay = 0.5f;
    void Start()
    {
        cloudPosition = transform.position;
        jumpAngleInRad = jumpAngle * Mathf.Deg2Rad;
    }
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
        {
            
            transform.position = new Vector3(cloudPosition.x, cloudPosition.y - verticalCloudDisplacement, cloudPosition.z);
            Rigidbody2D rb2d = collision.GetComponent<Rigidbody2D>();
            StartCoroutine(SetCloudToOriginalPosition(rb2d));
        }
    }

    IEnumerator SetCloudToOriginalPosition(Rigidbody2D rb2d)
    {
        yield return new WaitForSeconds(delay);
        jumpDirection = new Vector2(Mathf.Cos(jumpAngleInRad), Mathf.Sin(jumpAngleInRad));
        rb2d.AddForce(jumpDirection * jumpingForce, ForceMode2D.Impulse);
        transform.position = cloudPosition;
    }
}