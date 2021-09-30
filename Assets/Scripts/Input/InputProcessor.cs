using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputProcessor : MonoBehaviour
{
    public bool Used;

    public abstract void ProcessUse();
}
