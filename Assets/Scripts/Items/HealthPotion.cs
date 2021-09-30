public class HealthPotion : Potion
{
    public float AddedHealth;

    /// <summary>
    /// Adds <see cref="AddedHealth"/> to the player.
    /// </summary>
    public override void Use()
    {
        base.Use();
        //Add health to player
        throw new System.NotImplementedException("Add health to player not implemented.");
    }
}
