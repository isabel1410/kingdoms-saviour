using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerInputProcessor : InputProcessor
{
    public PauseMovementEvent PauseMovementEvent;
    public PauseItemsEvent PauseItemsEvent;
    private bool itemsPaused;

    public void OnUseInput(InputAction.CallbackContext context)
    {
        if (itemsPaused)
        {
            return;
        }

        if (context.started)
        {
            OnUse.Invoke();
        }
    }

    public void OnShieldUseInput(InputAction.CallbackContext context)
    {
        if (itemsPaused)
        {
            return;
        }

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
            PauseMovementEvent.Invoke();
            PauseItemsEvent.Invoke();
        }
    }

    public void ToggleItems(bool paused)
    {
        itemsPaused = paused;
    }
}

[System.Serializable]
public class PauseItemsEvent : UnityEvent { }