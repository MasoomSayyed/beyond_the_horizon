using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementSystemDifferentModes : MonoBehaviour
{
    public static MovementSystemDifferentModes Instance { get; private set; }

    private Coroutine dashPropelTimerCoroutine;

    private Rigidbody2D playerRigidbody;

    private Vector2 lastMoveDirSail;
    private Vector2 lastMoveDirSub;

    private bool isGliding = false;
    private bool canPropel = false;
    private bool canSubmarine = false;


    private void Awake()
    {
        Instance = this;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    //The inputs and settings when on above the water
    public void SailingModeInputs()
    {
        //makes the ship don't flip
        transform.localScale = Vector3.one;

        playerRigidbody.mass = 1f;
        playerRigidbody.gravityScale = 1f;

        float speed = 300f;

        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveDir = new Vector2(moveInput, 0);
        if (moveDir.x != 0)
        {
            lastMoveDirSail.x = moveDir.x;
        }
        playerRigidbody.AddForce(moveDir * speed * Time.deltaTime);

        //float rotationSpeed = 10;
        transform.right = lastMoveDirSail;   //Vector3.Slerp(transform.right, moveDir, rotationSpeed * Time.deltaTime);

        Glide();
    }

    // to handle the code for gliding reducing gravity
    private void Glide()
    {
        if (Input.GetKey(KeyCode.Space) && StaminaBar.Instance.IsStaminaAvailaible() != true && !IsTouchingWater())
        {
            isGliding = true;
            playerRigidbody.drag = .3f;
            playerRigidbody.gravityScale = .1f;
            StaminaBar.Instance.DepleteStamina(.6f);
        }

        else
        {
            isGliding = false;
        }


    }

    // this handels the boost given to player when coming out of water by dashing
    public void Propel()
    {
        float propelForce = 300f;
        playerRigidbody.AddForce(Vector3.up * propelForce);
    }

    // these handles inputs when underwater
    public void SubmarineModeInputs()
    {
        playerRigidbody.mass = 5f;
        playerRigidbody.gravityScale = 0.1f;
        //makes the ship don't flip
        transform.localScale = Vector3.one;

        float speed = 850f;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(horizontal, vertical).normalized;

        if (moveDir != Vector3.zero)
        {
            lastMoveDirSub = moveDir;
        }

        playerRigidbody.AddForce(moveDir * speed * Time.deltaTime);

        float rotationSpeed = 5f;
        float angle = Mathf.Atan2(lastMoveDirSub.y, lastMoveDirSub.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * rotationSpeed);

        Vector3 localScale = Vector3.one;
        localScale.x = 1f;
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = +1f;
        }

        transform.localScale = localScale;

        //transform.right = Vector3.Lerp(transform.right, lastMoveDirSub, rotationSpeed * Time.deltaTime);
    }


    public Vector3 GetEulerAngle()
    {
        return transform.eulerAngles;
    }

    public bool IsGliding()
    {
        return isGliding;
    }
    public bool CanPropel()
    {
        return canPropel;
    }

    // this is to implement the dash
    public void Dash()
    {
        float dashForce = 25f;
        playerRigidbody.AddForce(lastMoveDirSub * dashForce, ForceMode2D.Impulse);
    }

    // it handles the duration to which player can dash out of water and can jump
    // as player is not allowed to be boosted if not dashing while coming out of water
    public void DashPropelTimer()
    {
        if (dashPropelTimerCoroutine != null)
        {
            StopCoroutine(dashPropelTimerCoroutine);
        }

        dashPropelTimerCoroutine = StartCoroutine(DashPropelTimerCoroutine());
    }

    private IEnumerator DashPropelTimerCoroutine()
    {
        float dashPropelWaitTimer = 1.5f;
        canPropel = true;
        yield return new WaitForSeconds(dashPropelWaitTimer);
        canPropel = false;
    }

    // this returns if player is touching the water so it cannot enter in sub mode in the air
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            canSubmarine = true;
        }
        else
        {
            canSubmarine = false;
        }
    }
    public bool IsTouchingWater()
    {
        return canSubmarine;
    }

}
