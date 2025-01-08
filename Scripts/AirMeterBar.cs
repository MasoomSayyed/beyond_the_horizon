using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirMeterBar : MonoBehaviour
{
    public static AirMeterBar Instance;

    private bool isRefilling = false;
    private void Awake()
    {
        Instance = this;
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
            RefillAirMeter();
        }
    }

    public void RefillAirMeter()
    {
        isRefilling = true;
        airMeterImage.fillAmount += .1f * Time.deltaTime;
    }
}
