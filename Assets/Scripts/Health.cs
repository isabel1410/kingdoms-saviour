using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    private float maxHealth = 100f;
    private float currentHealth;
    [SerializeField] Healthbar healthBar;
    [SerializeField] GameObject DeadScene;
    [SerializeField] GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            healthBar.TakeDamage(damage);
        }
        if (currentHealth <= 0)
        {
            DeadScene.SetActive(true);
            UI.SetActive(false);
        }
    }

    public void UseHealthPotion(float health)
    {
        Debug.Log(currentHealth);
        if (currentHealth + health <= maxHealth)
        {
            currentHealth += health;
            healthBar.UseHealthPotion(health);
        }
    }

}
