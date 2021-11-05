using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMilitia : Enemy
{
    public GameObject orcMilitia;
    private void Start()
    {

    }
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
            Die(orcMilitia);
        }
    }

    public override void Die(GameObject orc)
    {
        // For now we'll use SetActive(false) instead of Destroy();
        orc.SetActive(false);
    }
}
