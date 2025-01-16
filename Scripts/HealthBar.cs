using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance;

    private string currentSceneName;

    private float maxHealth = 100f;
    [SerializeField] private Image healthBarImage;

    private float currentHealth;

    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
        healthBarImage.fillAmount = currentHealth;
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        RestartScene();
    }

    public void TakeDamage(float Damage)
    {
        currentHealth -= Damage;
        healthBarImage.fillAmount = currentHealth / maxHealth;
    }
    public void RestoreHealth(float healAmt)
    {
        currentHealth += healAmt;
        healthBarImage.fillAmount = currentHealth / maxHealth;
    }


    public void DepleteHealth()
    {
        currentHealth -= 10f * Time.deltaTime;
        healthBarImage.fillAmount = currentHealth / maxHealth;
    }

    /*private void RefillHealth()
    {
        if (currentHealth < 10)

        {
            currentHealth = maxHealth;
            healthBarImage.fillAmount += currentHealth / maxHealth;
        }
    }*/

    private void RestartScene()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
