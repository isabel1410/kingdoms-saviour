public class FireBow : Weapon
{
    public byte Ammo;

    public override void Use()
    {
        if (Ammo == 0)
        {
            return;
        }

        base.Use();
        //Deal damage to enemy
        throw new System.NotImplementedException("Deal damage to enemy.");
    }
}
