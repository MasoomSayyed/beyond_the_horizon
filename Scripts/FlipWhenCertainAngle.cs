using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWhenCertainAngle : MonoBehaviour
{
    private SpriteRenderer shipSprite;

    private void Awake()
    {
        shipSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (MovementSystemDifferentModes.Instance.GetEulerAngle().z < 90)
        {
            shipSprite.flipY = false;
        }
        else
        {
            shipSprite.flipY = true;
        }
    }
}
