using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMilitia : Enemy
{
    public GameObject orcMilitia;
    public WaveController waveController;

    public OrcMilitia(float MaxHealth, float EnemySpeed, float AttackDamage, float AttackCooldown)
    {
        maxHealth = MaxHealth;
        enemySpeed = EnemySpeed;
        attackDamage = AttackDamage;
        attackCooldown = AttackCooldown;
    }

    private void Start()
    {

    }
    public override void Attack()
    {
        if (waveController.enemiesActivated && Time.time < attackCooldown)
        {
            waveController.Animator.Play("Attack");

        }
    }

    public override void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
        if (currentHealth <= 0)
        {
            Die(orcMilitia);
        }
    }

    public override void Die(GameObject orc)
    {
        // For now we'll use SetActive(false) instead of Destroy();
        orc.SetActive(false);
    }
}
