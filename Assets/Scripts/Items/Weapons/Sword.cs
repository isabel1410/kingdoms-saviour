using UnityEngine;

public class Sword : MeleeWeapon
{
    public Sword(string name, float damage, float range)
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
            Animator.Play("SwordAttack");
            Hit(Damage);
        }
        Debug.Log("Sword used!");
    }
}
