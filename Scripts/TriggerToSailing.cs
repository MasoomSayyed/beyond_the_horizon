using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToSailing : MonoBehaviour
{
    private PlayerInput playerInput;

    private bool isJumping = false;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sailing") && playerInput.shipMode == PlayerInput.ShipModes.Submarine)
        {
            playerInput.shipMode = PlayerInput.ShipModes.Sailing;
            isJumping = true;
            MovementSystemDifferentModes.Instance.Propel();
        }
    }

    public bool IsJumping()
    {
        return isJumping;
    }

}
