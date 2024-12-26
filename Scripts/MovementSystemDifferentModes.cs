using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementSystemDifferentModes : MonoBehaviour
{
    public static MovementSystemDifferentModes Instance { get; private set; }



    private Rigidbody2D playerRigidbody;

    private Vector2 lastMoveDir;

    private bool isJumping = false;


    private void Awake()
    {
        Instance = this;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void SailingModeInputs()
    {
        playerRigidbody.mass = 1f;
        playerRigidbody.gravityScale = 1f;

        float speed = 300f;

        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveDir = new Vector2(moveInput, 0);
        if (moveDir.x != 0)
        {
            lastMoveDir.x = moveDir.x;
        }
        playerRigidbody.AddForce(moveDir * speed * Time.deltaTime);

        //float rotationSpeed = 10;
        transform.right = lastMoveDir;   //Vector3.Slerp(transform.right, moveDir, rotationSpeed * Time.deltaTime);

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
        float jumpForce = 300f;
        playerRigidbody.AddForce(Vector3.up * jumpForce);
    }

    private void Glide()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.drag = .3f;
            playerRigidbody.gravityScale = .1f;
        }
    }

    public void Propel()
    {
        float propelForce = 500f;
        playerRigidbody.AddForce(Vector3.up * propelForce);
    }

    public void SubmarineModeInputs()
    {
        playerRigidbody.mass = 8.5f;
        playerRigidbody.gravityScale = 0.1f;

        float speed = 1000f;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        playerRigidbody.AddForce(moveDirection * speed * Time.deltaTime);

        float rotationSpeed = 5f;
        transform.right = Vector3.Slerp(transform.right, moveDirection, rotationSpeed * Time.deltaTime);
    }


}
