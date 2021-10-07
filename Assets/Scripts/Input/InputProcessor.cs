using UnityEngine;
using UnityEngine.Events;

public abstract class InputProcessor : MonoBehaviour
{
    public UseEvent OnUse;
    public ShieldUseEvent OnShieldUse;
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
            OnShieldUse.Invoke(value);// True
        }
    }
}

[System.Serializable]
public class UseEvent: UnityEvent { }

[System.Serializable]
public class ShieldUseEvent : UnityEvent<bool> { }