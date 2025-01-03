using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance;

    private float maxHealth = 100f;
    private float HealthToDeplete = 40f;
    public Image  healthBar;

    private float currentStamina;

    private void Awake()
    {
        Instance = this;
    }
}
