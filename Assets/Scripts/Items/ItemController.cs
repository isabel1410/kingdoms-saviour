using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Item[] items;
    private Item currentItem;

    private void Start()
    {
        items = new Item[]
        {
            new Sword("Sword", 15f, 10f),
            new Bow("Bow", 10f, 50f),
            new FireBow("Firebow", 10f, 50f)
        };
        currentItem = items[0];
    }

    private void Update()
    {
        Debug.Log(items[0].ToString());
    }

    public void SwitchToSword()
    {
        Debug.Log("Sword selected!");
        Item.Switch(currentItem, items[0]);
        currentItem = items[0];
    }

    public void SwitchToBow()
    {
        Debug.Log("Bow selected!");
        Item.Switch(currentItem, items[1]);
        currentItem = items[1];
    }

    public void SwitchToFireBow()
    {
        Debug.Log("Fire bow selected!");
        Item.Switch(currentItem, items[2]);
        currentItem = items[2];
    }
}
