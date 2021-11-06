using UnityEngine;

public class Sword : MeleeWeapon
{
    public Sword(string name, float damage, float range, int cooldown)
    {
        Name = name;
        Damage = damage;
        Range = range;
        Cooldown = cooldown;
    }

    public override void Use()
    {
        base.Use();
        Animator.Play("SwordAttack");
        Hit(Damage);
        Debug.Log("Sword used!");
    }
}
