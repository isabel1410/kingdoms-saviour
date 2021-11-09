using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float enemySpeed;
    public float attackDamage;
    public float attackCooldown;
    public float nextTimeAttack = 0f;
    public bool IsDead;

    public enum enemyType
    {
        Melee,
        Range
    }

    public uint goldReward;

    public abstract IEnumerator Attack(GameObject enemy);

    public abstract void TakeDamage(float damage);

    public virtual void Die(GameObject enemy)
    {
        IsDead = true;
    }
}
