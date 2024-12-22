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
        if (Input.GetKeyDown(KeyCode.Space) && shipMode == ShipModes.Sailing)
        {
            MovementSystemDifferentModes.Instance.JumpAndGlide();
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
                MovementSystemDifferentModes.Instance.SailingModeInputs();
                break;
            case ShipModes.Submarine:
                MovementSystemDifferentModes.Instance.SubmarineModeInputs();
                break;
        }
    }

}
