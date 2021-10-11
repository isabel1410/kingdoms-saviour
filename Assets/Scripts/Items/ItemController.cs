using System;
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
            Instantiate(Resources.Load<Sword>("Prefabs/Items/Weapons/Sword")),
            Instantiate(Resources.Load<Bow>("Prefabs/Items/Weapons/Bow")),
            Instantiate(Resources.Load<FireBow>("Prefabs/Items/Weapons/Fire Bow"))
        };
        currentItem = items[0];
    }

    private void Update()
    {
        Debug.Log(currentItem);
    }

    public void SwitchToSword()
    {
        currentItem.Switch(items[0], 1);
        currentItem = items[0];
        Debug.Log("Sword selected!");
    }

    public void SwitchToBow()
    {
        currentItem.Switch(items[1], 2);
        currentItem = items[1];
        Debug.Log("Bow selected!");
    }

    public void SwitchToFireBow()
    {
        currentItem.Switch(items[2], 3);
        currentItem = items[2];
        Debug.Log("Fire bow selected!");
    }

    public void UseItem()
    {
        currentItem.Use();
    }
}
