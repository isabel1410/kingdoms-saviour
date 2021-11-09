using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public InputProcessor InputProcessor;

    public List<Item> Items;
    public uint Gold;
    //private string CurrentItem;

    private void Start()
    {
        // Update required
        // Maybe select item from previous level?
        //CurrentItem = "Sword";
    }

    public void OnUse()
    {
        //Debug.Log(CurrentItem + " used.");
    }

    public void OnShieldUse(bool raised)// Always false
    {
        Debug.Log("Shield " + (raised ? "raised" : "lowered") + ".");
    }
}
