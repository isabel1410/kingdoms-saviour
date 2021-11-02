using UnityEngine;

public class Sword : Weapon
{
    public Sword(string name, float damage, float range)
    {
        Name = name;
        Damage = damage;
        Range = range;
    }

    public override void Use()
    {
        //if (routeMovement.choosingRoute)
        //{
        //    Debug.Log("Can't use now");
        //    return;
        //}

        base.Use();
        if (Animator != null)
        {
            Animator.Play("SwordAttack");
            Hit();
        }
        Debug.Log("Sword used!");
    }
}
