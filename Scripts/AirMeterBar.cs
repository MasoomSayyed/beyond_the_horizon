using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirMeterBar : MonoBehaviour
{
    public static AirMeterBar Instance;

    private float maxAir = 100f;
    private float currentAir;

    private bool isRefilling = false;
    private void Awake()
    {
        Instance = this;
        currentAir = maxAir;
    }

    [SerializeField] private Image airMeterImage;

    private void Update()
    {

        if (PlayerInput.Instance.shipMode == PlayerInput.ShipModes.Submarine)
        {
            DepleteAirMeter();
        }
        else
        {
            RefillAirMeter();
        }

    }

    private void DepleteAirMeter()
    {
        airMeterImage.fillAmount -= .01f * Time.deltaTime;

    }

    public void RefillAirMeter()
    {
        isRefilling = true;
        currentAir += 20f * Time.deltaTime;
        airMeterImage.fillAmount = currentAir / maxAir;
    }
}
