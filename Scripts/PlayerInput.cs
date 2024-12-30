using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public enum ShipModes
    {
        Sailing,
        Submarine,
    }

    public ShipModes shipMode;

    private void Start()
    {
        shipMode = ShipModes.Sailing;
    }

    private void Update()
    {
        ModeSwitch();
        if (Input.GetKeyDown(KeyCode.LeftShift) && shipMode == ShipModes.Submarine)
        {
            MovementSystemDifferentModes.Instance.Dash();
        }
    }

    private void ModeSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Q) && shipMode == ShipModes.Submarine)
        {
            shipMode = ShipModes.Sailing;
        }

        else if (Input.GetKeyDown(KeyCode.Q) && shipMode == ShipModes.Sailing)
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
