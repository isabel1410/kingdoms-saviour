using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerInputProcessor : InputProcessor
{
    public PauseEvent OnPause;

    public void OnUseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnUse.Invoke();
        }
    }

    public void OnShieldUseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ShieldUsed = true;
        }
        else if (context.canceled)
        {
            ShieldUsed = false;
        }
    }

    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnPause.Invoke();
        }
    }
}

[System.Serializable]
public class PauseEvent : UnityEvent { }