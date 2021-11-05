using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcSoldier : Enemy
{
    public GameObject orcSoldier;
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
        if (currentHealth <= 0)
        {
            Die(orcSoldier);
        }

    }
    public override void Die(GameObject orcSoldier)
    {
        // For now we'll use SetActive(false) instead of Destroy();
        orcSoldier.SetActive(false);
    }
}
