using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance;

    public enum ShipModes
    {
        Sailing,
        Submarine,
    }

    public ShipModes shipMode;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        shipMode = ShipModes.Sailing;
    }

    private void Update()
    {
        ModeSwitch();
        if (Input.GetKeyDown(KeyCode.LeftShift) && shipMode == ShipModes.Submarine)
        {
            MovementSystemDifferentModes.Instance.DashPropelTimer();
            if (StaminaBar.Instance.IsSprintingAllowed())
            {
                StaminaBar.Instance.DepleteStamina();
                MovementSystemDifferentModes.Instance.Dash();
            }
        }
    }

    private void ModeSwitch()
    {
        /* if (Input.GetKeyDown(KeyCode.Q) && shipMode != ShipModes.Submarine)
         {
             shipMode = ShipModes.Sailing;
         }*/

        if (Input.GetKey(KeyCode.S) && shipMode == ShipModes.Sailing)
        {
            shipMode = ShipModes.Submarine;
        }



        switch (shipMode)
        {
            case ShipModes.Sailing:
                // Debug.Log("Siwtched to Sailing mode !");
                MovementSystemDifferentModes.Instance.SailingModeInputs();
                break;
            case ShipModes.Submarine:
                // Debug.Log("Siwtched to Submarine mode !");
                MovementSystemDifferentModes.Instance.SubmarineModeInputs();
                break;
        }
    }

}
