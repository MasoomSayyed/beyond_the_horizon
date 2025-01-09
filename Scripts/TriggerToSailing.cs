using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerToSailing : MonoBehaviour
{
    public static TriggerToSailing Instance { get; private set; }

    private PlayerInput playerInput;

    private bool isJumping = false;
    private void Awake()
    {
        Instance = this;
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Sailing") && playerInput.shipMode == PlayerInput.ShipModes.Submarine)
        {
            playerInput.shipMode = PlayerInput.ShipModes.Sailing;
            isJumping = true;
            if (MovementSystemDifferentModes.Instance.CanPropel())
            {
                MovementSystemDifferentModes.Instance.Propel();
            }
        }

    }


    public bool IsJumping()
    {
        return isJumping;
    }

    public void SetIsJumpingFalse()
    {

        isJumping = false;
    }

}
