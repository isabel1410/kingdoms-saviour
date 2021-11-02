using UnityEngine;

public class FireBow : Weapon
{
    public byte Ammo;

    public FireBow(string name, float damage, float range)
    {
        Name = name;
        Damage = damage;
        Range = range;
    }

    public override void Use()
    {
        if (Ammo == 0)
        {
            Debug.Log("No ammo left.");
            return;
        }

        base.Use();
        if (Animator != null)
        {
            Animator.Play("FireBowAttack");
            Hit();
            Ammo--;
        }
        Debug.Log("Fire arrow fired");
    }
}
