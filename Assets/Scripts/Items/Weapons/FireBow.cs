using UnityEngine;

public class FireBow : RangeWeapon
{
    public byte Ammo;
    public FireBow(string name, float damage, float range, int cooldown)
    {
        Name = name;
        Damage = damage;
        Range = range;
        Cooldown = cooldown;
    }

    public override void Use()
    {
        if (Ammo == 0)
        {
            Debug.Log("No ammo left.");
            return;
        }
        base.Use();
        Animator.Play("FireBowAttack");
        Hit(Damage);
        Ammo--;
        Debug.Log("Fire arrow fired");
    }
}
