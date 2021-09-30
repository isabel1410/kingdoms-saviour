using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputProcessor : InputProcessor
{
    private bool used;

    public override void ProcessUse()
    {
        Used = used;
    }

    // Update is called once per frame
    private void Update()
    {
        ProcessUse();
    }

    public void OnUse(InputAction.CallbackContext context)
    {
        used = context.performed;
    }
}
