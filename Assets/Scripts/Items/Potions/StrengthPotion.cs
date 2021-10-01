public class StrengthPotion : Potion
{
    public float AddedAttackDamagePercentage;

    /// <summary>
    /// Adds <see cref="AddedAttackDamagePercentage"/> to the player.
    /// </summary>
    public override void Use()
    {
        if (Amount != 0)
            base.Use();
        //Add attack damage to player
        throw new System.NotImplementedException("Add attack damage to player not implemented.");
    }
}
