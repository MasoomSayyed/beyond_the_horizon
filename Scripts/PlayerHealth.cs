using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 120f;
    public float maxHealth = 100f;
    [SerializeField] private float seaMineDamage = 20f;
    [SerializeField] private Image healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (healthBar != null)
        {
            Debug.Log("Found HealthBar");
            healthBar.fillAmount = health / maxHealth;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SeaMine")
        {
            health -= seaMineDamage;
            healthBar.fillAmount = health / maxHealth;
        }

    }
}
