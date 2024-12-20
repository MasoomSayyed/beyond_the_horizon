using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public enum ShipModes
    {
        Sailing,
        Flying,
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
    }

    private void ModeSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            shipMode = ShipModes.Sailing;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && shipMode != ShipModes.Submarine)
        {
            shipMode = ShipModes.Flying;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && shipMode != ShipModes.Flying)
        {
            shipMode = ShipModes.Submarine;
        }

        switch (shipMode)
        {
            case ShipModes.Sailing:
                MovementSystemDifferentModes.Instance.SailingModeInputs();
                break;
            case ShipModes.Flying:
                MovementSystemDifferentModes.Instance.FlyingModeInputs();
                break;
            case ShipModes.Submarine:
                MovementSystemDifferentModes.Instance.SubmarineModeInputs();
                break;
        }
    }

}
