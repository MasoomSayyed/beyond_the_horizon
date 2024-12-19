using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D shipRigidbody2D;

    private void Awake()
    {
        shipRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        // Movement of ship
        Vector3 inputDir = new Vector3(0, 0, 0);

        // just to test jump and sink from spacebar and 'C' key
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            inputDir.x = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputDir.x = -1f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shipRigidbody2D.AddForce(new Vector2(0, 500));
        }
        if (Input.GetKey(KeyCode.C))
        {
            moveY = -1f;
            transform.position += new Vector3(0, moveY) * 10f * Time.deltaTime;
        }

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
        transform.position += moveDir * 2f * Time.deltaTime;
    }

    private void HandleRotation()
    {
        // For rotation
        float rotateDir = 0f;
        if (Input.GetKey(KeyCode.Q))
        {
            rotateDir = 1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotateDir = -1f;
        }

        float rotateSpeed = 50f;

        transform.eulerAngles += new Vector3(0, 0, rotateDir * rotateSpeed * Time.deltaTime);
    }
}
