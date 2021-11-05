using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float maxHealth = 100f;
    private float currentHealth;
    [SerializeField] private Healthbar healthBar;
    [SerializeField] private GameObject DeadScene;
    [SerializeField] private GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Taking damage");
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
        if (currentHealth <= 0)
        {
            DeadScene.SetActive(true);
            UI.SetActive(false);
        }
    }

    public void UseHealthPotion(float health)
    {
        Debug.Log("Taking damage");
        Debug.Log(currentHealth);
        if (currentHealth + health <= maxHealth)
        {
            currentHealth += health;
            healthBar.UseHealthPotion(health);
        }
    }
}
