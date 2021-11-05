using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    public GameObject enemy;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage, Enemy enemy)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
        if (currentHealth <= 0)
        {
            enemy.Die(enemy.gameObject);
        }
    }
}
