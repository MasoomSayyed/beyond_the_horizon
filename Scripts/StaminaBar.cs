using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public static StaminaBar Instance;

    private float maxStamina = 100f;
    private float staminaToDeplete = 40f;
    private float staminaRecoveryRate = 10f;
    public Image staminaBar;

    private float currentStamina;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaBar();
    }

    void Update()
    {
        if (currentStamina < maxStamina)
        {
            RecoverStamina();
        }
    }

    public bool IsSprintingAllowed()
    {

        return currentStamina > 30f;
    }

    public void DepleteStamina()
    {
        currentStamina -= staminaToDeplete;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        UpdateStaminaBar();
    }

    private void RecoverStamina()
    {
        currentStamina += staminaRecoveryRate * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        UpdateStaminaBar();
    }

    private void UpdateStaminaBar()
    {
        staminaBar.fillAmount = currentStamina / maxStamina;
    }
}
