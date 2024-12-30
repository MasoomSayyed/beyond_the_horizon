using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWhenCertainAngle : MonoBehaviour
{
    private SpriteRenderer shipSprite;
    public PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        shipSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (MovementSystemDifferentModes.Instance.GetEulerAngle().z >= 90 || MovementSystemDifferentModes.Instance.GetEulerAngle().z <= -90 && playerInput.shipMode == PlayerInput.ShipModes.Sailing)
        {
            shipSprite.flipY = true;
        }
        else
        {
            shipSprite.flipY = false;
        }
    }
}
