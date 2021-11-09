using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMilitia : Enemy
{
    public GameObject orcMilitia;
    public Rigidbody projectile;
    public GameObject arrowSpawner;
    public Transform target;
    GameObject player;

    public OrcMilitia(float MaxHealth, float EnemySpeed, float AttackDamage, float AttackCooldown)
    {
        maxHealth = MaxHealth;
        enemySpeed = EnemySpeed;
        attackDamage = AttackDamage;
        attackCooldown = AttackCooldown;
    }

    public override IEnumerator Attack(GameObject enemy)
    {
        while (currentHealth > 0)
        {
            enemy.gameObject.GetComponent<Animator>().SetBool("CanShoot", true);
            // Instantiate arrow towards player
            Rigidbody arrow = Instantiate(projectile, arrowSpawner.transform.position, transform.rotation);
            arrow.transform.LookAt(target);
            arrow.GetComponent<Rigidbody>().AddForce(arrow.transform.forward * 600);

            Debug.Log("Enemy attacking");

            // If arrow hits player..
            player = GameObject.FindGameObjectWithTag("Player").gameObject;
            if (arrow.detectCollisions = player)
            {
                player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                Debug.Log("Player hit");
            }
            enemy.gameObject.GetComponent<Animator>().SetBool("CanShoot", false);
            yield return new WaitForSecondsRealtime(attackCooldown);
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
        // Play animation when enemy has died
        orc.gameObject.GetComponent<Animator>().SetBool("EnemyDead", true);
    }
}
