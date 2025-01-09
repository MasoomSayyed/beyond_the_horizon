using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public static StaminaBar Instance;

    private float maxStamina = 100f;
    private float staminaRecoveryRate = 2f;
    public Image staminaBar;

    private float currentStamina;

    private bool isStaminaAvailaible = true;

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

    public void DepleteStamina(float staminaToDeplete)
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

    public bool IsStaminaAvailaible()
    {
        if (currentStamina <= 10)
        {
            isStaminaAvailaible = true;
        }
        else
        {
            isStaminaAvailaible = false;
        }
        return isStaminaAvailaible;
    }
}
