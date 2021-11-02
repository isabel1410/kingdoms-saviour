using UnityEngine;

public class Bow : Weapon
{
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
            Hit();
        }
        Debug.Log("Arrow fired");
    }

}
