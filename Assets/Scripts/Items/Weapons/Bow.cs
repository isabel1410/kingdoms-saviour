using UnityEngine;

public class Bow : Weapon
{
    public Rigidbody projectile;
    public Bow(string name, float damage, float range)
    {
        Name = name;
        Damage = damage;
        Range = range;
    }

    public override void Use()
    {
        //if (routeMovement.choosingRoute)
        //{
        //    Debug.Log("Can't shoot now.");
        //    return;
        //}
        base.Use();
        if (Animator != null)
        {
            Animator.Play("BowAttack");

            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);


            clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * 1500);

            clone.GetComponent<Rigidbody>().transform.rotation.SetLookRotation(transform.position + projectile.velocity);
            Hit();
        }
        Debug.Log("Arrow fired");
    }

}
