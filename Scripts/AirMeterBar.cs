using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirMeterBar : MonoBehaviour
{
    private void Awake()
    {
        airMeterImage.fillAmount = 1;
    }

    [SerializeField] private Image airMeterImage;

    private void Update()
    {
        if (PlayerInput.Instance.shipMode == PlayerInput.ShipModes.Submarine)
        {
            airMeterImage.fillAmount -= .01f * Time.deltaTime;
        }
        else
        {
            airMeterImage.fillAmount += Time.deltaTime;
        }
    }

    public void RefillAirMeter()
    {
        airMeterImage.fillAmount += .1f * Time.deltaTime;
    }
}
