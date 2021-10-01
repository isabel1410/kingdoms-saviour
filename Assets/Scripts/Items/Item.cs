using System.Timers;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public Animation UseAnimation;
    public Animation SwitchFromAnimation;
    public Animation SwitchToAnimation;
    public float Cooldown;
    public float SwitchFromCooldown;
    public float SwitchToCooldown;

    [HideInInspector]
    public bool Ready;

    protected Timer cooldownTimer;

    /// <summary>
    /// Switches from <paramref name="fromItem"/> to <paramref name="toItem"/>.
    /// Plays animations and starts switch cooldown.
    /// </summary>
    /// <param name="fromItem"></param>
    /// <param name="item"></param>
    public static void Switch(Item fromItem, Item toItem)
    {
        fromItem.SwitchFrom();
        while (!fromItem.Ready) { }
        toItem.SwitchTo();
    }

    /// <summary>
    /// Use this item.
    /// Plays <see cref="UseAnimation"/> and starts timer based on <see cref="Cooldown"/>.
    /// </summary>
    public virtual void Use()
    {
        UseAnimation?.Play();
        Ready = false;
        cooldownTimer.Interval = Cooldown;
        cooldownTimer.Start();
    }

    /// <summary>
    /// Switch from this weapon to another weapon.
    /// Plays <see cref="SwitchFromAnimation"/> and starts timer based on <see cref="SwitchFromCooldown"/>.
    /// </summary>
    private void SwitchFrom()
    {
        SwitchFromAnimation?.Play();
        Ready = false;
        cooldownTimer.Interval = SwitchFromCooldown;
        cooldownTimer.Start();
    }

    /// <summary>
    /// Switch to this weapon from another weapon.
    /// Playes <see cref="SwitchToAnimation"/> and starts timer based on <see cref="SwitchToCooldown"/>.
    /// </summary>
    private void SwitchTo()
    {
        SwitchToAnimation?.Play();
        Ready = false;
        cooldownTimer.Interval = SwitchToCooldown;
        cooldownTimer.Start();
    }

    private void Start()
    {
        cooldownTimer = new Timer();
        cooldownTimer.Elapsed += CooldownTimer_Elapsed;
    }

    private void CooldownTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        Ready = true;
        cooldownTimer.Stop();
    }
}
