using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public void Hit(float damage)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Range))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Enemies")
            {
                Debug.Log("Enemy hit.");
                //hit.transform.gameObject.GetComponent<Enemy>().currentHealth -= damage;
                hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }
}
