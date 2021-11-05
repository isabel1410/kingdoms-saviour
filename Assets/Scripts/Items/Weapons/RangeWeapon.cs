using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    public Rigidbody projectile;
    public GameObject arrowSpawner;
    private Vector3 mousePos = Input.mousePosition;
    private Vector3 aim;

    public void Hit(float damage)
    {
        Rigidbody arrow;
        arrow = Instantiate(projectile, arrowSpawner.transform.position, transform.rotation);
        mousePos = Input.mousePosition;
        mousePos += Camera.main.transform.forward * 4f;
        aim = Camera.main.ScreenToWorldPoint(mousePos);

        arrow.transform.LookAt(aim);
        arrow.GetComponent<Rigidbody>().AddForce(arrow.transform.forward * 600);
        arrow.GetComponent<Rigidbody>().transform.rotation.SetLookRotation(transform.position + projectile.velocity);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Range))
        {
            //Destroy(arrow.gameObject, 0.5f);
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Enemies")
            {
                Debug.Log("Enemy hit.");
                //hit.transform.gameObject.GetComponent<Enemy>().currentHealth -= damage;
                hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        //Destroy(arrow.gameObject, 1f);
    }
}
