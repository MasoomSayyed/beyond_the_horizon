using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance;

    private float maxHealth = 100f;
    [SerializeField] private Image healthBarImage;

    private float currentHealth;

    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
        healthBarImage.fillAmount = currentHealth;
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        healthBarImage.fillAmount = currentHealth / maxHealth;
    }
}
