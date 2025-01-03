using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    [SerializeField] private float seaMineDamage = 20f;
    private Image healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar = FindObjectsByType<Canvas>(FindObjectsSortMode.None)[0].GetComponentInChildren<Image>();
        if (healthBar != null)
        {
            Debug.Log("Found HealthBar");
            healthBar.fillAmount = health / maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
