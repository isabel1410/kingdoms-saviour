using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float enemySpeed;
    public float attackDamage;
    public enum enemyType
    {
        Melee,
        Range
    }

    public uint goldReward;

    public abstract void Attack();

    public abstract void TakeDamage(float damage);

    public abstract void Die(GameObject enemy);
}
