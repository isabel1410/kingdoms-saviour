using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBat : Enemy
{
    public GameObject demonBat;
    public override IEnumerator Attack(GameObject enemy)
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
            Die(demonBat);
        }
    }

    public override void Die(GameObject demonBat)
    {
        base.Die(demonBat);
        // For now we'll use SetActive(false) instead of Destroy();
        demonBat.SetActive(false);
    }
}
