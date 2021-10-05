using UnityEngine;
using UnityEngine.Events;

public abstract class InputProcessor : MonoBehaviour
{
    public UseEvent OnUse;
    public ShieldUseChangedEvent OnShieldUseChanged;
    private bool shieldUsed;

    public bool ShieldUsed
    {
        get
        {
            return shieldUsed;
        }
        set
        {
            shieldUsed = value;
            OnShieldUseChanged.Invoke(value);
        }
    }
}

[System.Serializable]
public class UseEvent: UnityEvent { }

[System.Serializable]
public class ShieldUseChangedEvent : UnityEvent<bool> { }