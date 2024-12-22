using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystemDifferentModes : MonoBehaviour
{
    public static MovementSystemDifferentModes Instance { get; private set; }



    private Rigidbody2D playerRigidbody;
    private BuoyancyEffector2D buoyancyEffector2D;
    private bool isJumping = false;
    private float speed = 300f;

    private void Awake()
    {
        Instance = this;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        buoyancyEffector2D = GameObject.FindGameObjectWithTag("Water").GetComponent<BuoyancyEffector2D>();
    }

    public void SailingModeInputs()
    {
        buoyancyEffector2D.density = 2f;

        Debug.Log("Siwtched to Sailing mode !");
        float speed = 300f;

        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * speed * Time.deltaTime, playerRigidbody.linearVelocity.y);
        playerRigidbody.AddForce(moveVelocity);
        Glide();
    }

    /* public void FlyingModeInputs()
     {
         Debug.Log("Siwtched to flying mode !");
         float flapForce = 500f;

         if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
         {
             playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, flapForce * Time.deltaTime);
         }

     }*/

    public void JumpAndGlide()
    {
        isJumping = true;
        float jumpForce = 300f;
        playerRigidbody.AddForce(Vector3.up * jumpForce);
    }

    private void Glide()
    {
        if (Input.GetKeyDown(KeyCode.G) && isJumping)
        {
            playerRigidbody.linearDamping = 3.2f;
            playerRigidbody.gravityScale = 0.2f;
        }
    }

    public void SubmarineModeInputs()
    {
        Debug.Log("Siwtched to Submarine mode !");
        buoyancyEffector2D.density = 0.1f;

        float speed = 100f;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        playerRigidbody.linearVelocity = moveDirection * speed * Time.deltaTime;
    }


}
