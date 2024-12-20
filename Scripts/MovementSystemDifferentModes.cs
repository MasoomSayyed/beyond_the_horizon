using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystemDifferentModes : MonoBehaviour
{
    public static MovementSystemDifferentModes Instance { get; private set; }

    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        Instance = this;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void SailingModeInputs()
    {
        Debug.Log("Siwtched to Sailing mode !");
        float speed = 300f;

        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * speed * Time.deltaTime, playerRigidbody.velocity.y);
        playerRigidbody.AddForce(moveVelocity);
    }

    public void FlyingModeInputs()
    {
        Debug.Log("Siwtched to flying mode !");
    }

    public void SubmarineModeInputs()
    {
        Debug.Log("Siwtched to Submarine mode !");
    }
}
