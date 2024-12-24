using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementSystemDifferentModes : MonoBehaviour
{
    public static MovementSystemDifferentModes Instance { get; private set; }



    private Rigidbody2D playerRigidbody;
    private BuoyancyEffector2D buoyancyEffector2D;
    private bool isJumping = false;


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

        Debug.Log("Siwtched to Sailing mode !");

        buoyancyEffector2D.density = 3f;
        playerRigidbody.gravityScale = 1f;

        float speed = 300f;

        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveDir = new Vector2(moveInput, 0);
        playerRigidbody.AddForce(moveDir * speed * Time.deltaTime);
        transform.right = moveDir;

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
            playerRigidbody.drag = 1f;
            playerRigidbody.gravityScale = 0.4f;
        }
    }

    public void SubmarineModeInputs()
    {
        Debug.Log("Siwtched to Submarine mode !");

        buoyancyEffector2D.density = 0.4f;
        playerRigidbody.gravityScale = 0.5f;

        float speed = 500f;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        playerRigidbody.AddForce(moveDirection * speed * Time.deltaTime);

        transform.right = Vector3.Slerp(transform.right, moveDirection, Time.deltaTime);
    }


}
