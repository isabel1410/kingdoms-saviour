public class ArmorPotion : Potion
{
    public float AddedArmorPercentage;

    /// <summary>
    /// Adds <see cref="AddedArmorPercentage"/> to the player.
    /// </summary>
    public override void Use()
    {
        if (Amount != 0)
            base.Use();
        //Add armor to player
        throw new System.NotImplementedException("Add armor to player not implemented.");
    }
}
