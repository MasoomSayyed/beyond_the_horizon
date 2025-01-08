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

    public void SailingModeInputs()
    {
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

    public void JumpAndGlide()
    {
        float jumpForce = 50f;
        playerRigidbody.AddForce(Vector3.up * jumpForce);
    }

    private void Glide()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isGliding = true;
            playerRigidbody.drag = .3f;
            playerRigidbody.gravityScale = .1f;
        }
        else
        {
            isGliding = false;
        }
    }

    public void Propel()
    {
        float propelForce = 300f;
        playerRigidbody.AddForce(Vector3.up * propelForce);
    }

    public void SubmarineModeInputs()
    {
        playerRigidbody.mass = 8.5f;
        playerRigidbody.gravityScale = 0.1f;

        float speed = 1000f;
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

    public bool IsTouchingWater()
    {
        /*  WaterWave waterWave = GetComponent<WaterWave>();
          if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 5f))
          {
              if (hit.transform != null && hit.transform.tag == waterWave.gameObject.tag)
              {
                  canSubmarine = true;
              }
              else
              {
                  canSubmarine = false;
              }
          }*/
        return canSubmarine;

    }

    public void Dash()
    {
        float dashForce = 50f;
        playerRigidbody.AddForce(lastMoveDirSub * dashForce, ForceMode2D.Impulse);
    }

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
}
