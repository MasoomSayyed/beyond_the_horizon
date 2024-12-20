using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystemDifferentModes : MonoBehaviour
{
    public static MovementSystemDifferentModes Instance { get; private set; }

    private Rigidbody2D playerRigidbody;
    public BuoyancyEffector2D buoyancyEffector2D;

    private void Awake()
    {
        Instance = this;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void SailingModeInputs()
    {
        buoyancyEffector2D.density = 2f;
        Debug.Log("Siwtched to Sailing mode !");
        float speed = 300f;

        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * speed * Time.deltaTime, playerRigidbody.velocity.y);
        playerRigidbody.AddForce(moveVelocity);
    }

    public void FlyingModeInputs()
    {
        Debug.Log("Siwtched to flying mode !");
        float flapForce = 500f;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, flapForce * Time.deltaTime);
        }

    }

    public void SubmarineModeInputs()
    {
        Debug.Log("Siwtched to Submarine mode !");
        buoyancyEffector2D.density = 0.01f;

        float speed = 100f;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        playerRigidbody.velocity = moveDirection * speed * Time.deltaTime;
    }

  
}
