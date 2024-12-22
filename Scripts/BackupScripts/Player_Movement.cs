//i just removed unused stuff here
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5f;
    public float flapForce = 10f;
    public Rigidbody2D rb;

    private bool isDiveMode = false;
    private GameObject water;
    private BuoyancyEffector2D buoyancyEffector;

    void Start()
    {
        water = GameObject.FindGameObjectWithTag("Water");
        if (water == null)
        {
            Debug.LogError("Water tag not found in the scene.");
            return;
        }

        // Attempt to get the BuoyancyEffector2D from the water object
        buoyancyEffector = water.GetComponent<BuoyancyEffector2D>();
        if (buoyancyEffector == null)
        {
            Debug.LogError("No BuoyancyEffector2D found on the water object.");
        }
    }
    void Update()
    {
        //checking if player is in Dive Mode
        if (isDiveMode)
        {
            //if player IS in dive mode
            DiveModeMovement();
        }
        else
        {
            //if player is NOT in dive mode then we call default mode
            DefaultModeMovement();
            //if user clicks W,space, or Up arrow to flap
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Flap();
            }
        }
        //clicking space to switch between default n dive mode
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleDiveMode();
        }
    }

    void DefaultModeMovement()
    {
        //this includes both (A&D keys) and (Left&Right arrows) in the horizontal thing
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        rb.linearVelocity = moveVelocity;
    }

    void Flap()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, flapForce);
    }



    void DiveModeMovement()
    {
        // horizontal gets all left n right keys which includes arrows n wasd
        float horizontal = Input.GetAxisRaw("Horizontal");
        // vertical gets all up n down keys which includes arrows n wasd
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        rb.linearVelocity = moveDirection * speed;
    }

    void ToggleDiveMode()
    {
        isDiveMode = !isDiveMode;
        if (isDiveMode)
        {
            rb.gravityScale = 5;
            rb.linearDamping = 2f;  // Water resistance

            //buoyancyEffector.density = .5f;
        }
        else
        {
            rb.gravityScale = 1;
            rb.linearDamping = 0;

            //buoyancyEffector.density = 2f;
        }
    }
    //Noor:I'd rather the rotation happen on their own like when i click up,down,left or right.
    //i can do right+down too for diagonal rotations. reduction of buttons is a good sign for great User Experience
    //private void HandleRotation()
    //{
    //    // For rotation
    //    float rotateDir = 0f;
    //    if (Input.GetKey(KeyCode.Q))
    //        rotateDir = 1f;
    //    if (Input.GetKey(KeyCode.E))
    //    {
    //        rotateDir = -1f;
    //    }
    //    float rotateSpeed = 50f;
    //    transform.eulerAngles += new Vector3(0, 0, rotateDir * rotateSpeed * Time.deltaTime);
    //}
}