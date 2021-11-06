using UnityEngine;

public class Bow : RangeWeapon
{
    public Bow(string name, float damage, float range, int cooldown)
    {
        Name = name;
        Damage = damage;
        Range = range;
        Cooldown = cooldown;
    }

    public override void Use()
    {
        base.Use();
        Animator.Play("BowAttack");
        Hit(Damage);
        Debug.Log("Arrow fired");
    }

}
