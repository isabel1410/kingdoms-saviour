using UnityEngine;

public class Bow : RangeWeapon
{
    public Bow(string name, float damage, float range)
    {
        Name = name;
        Damage = damage;
        Range = range;
    }

    public override void Use()
    {
        base.Use();
        if (Animator != null)
        {
            Animator.Play("BowAttack");
            Hit(Damage);
        }
        Debug.Log("Arrow fired");
    }

}
