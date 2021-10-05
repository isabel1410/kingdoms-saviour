using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public InputProcessor InputProcessor;
    private string CurrentItem;

    private void Start()
    {
        CurrentItem = "Sword";
    }

    public void OnUse()
    {
        Debug.Log(CurrentItem + " used.");
    }

    public void OnShieldUse(bool used)
    {
        Debug.Log("Shield " + (used ? "raised" : "lowered") + ".");
    }
}
