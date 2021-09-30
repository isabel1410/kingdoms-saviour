using UnityEngine;

public abstract class InputProcessor : MonoBehaviour
{
    public bool Used;

    public abstract void ProcessUse();
}
