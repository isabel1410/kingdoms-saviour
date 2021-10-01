public class HealthPotion : Potion
{
    public float AddedHealthPercentage;

    /// <summary>
    /// Adds <see cref="AddedHealthPercentage"/> to the player.
    /// </summary>
    public override void Use()
    {
        if (Amount != 0)
            base.Use();
        //Add health to player
        throw new System.NotImplementedException("Add health to player not implemented.");
    }
}
