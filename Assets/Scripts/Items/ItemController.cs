using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Item[] items;
    private Item currentItem;
    public GameObject SwordWeapon;
    public GameObject BowWeapon;
    public GameObject FireBowWeapon;
    public bool canUseWeapon;

    private void Start()
    {
        Sword sword = SwordWeapon.GetComponent<Sword>();
        Bow bow = BowWeapon.GetComponent<Bow>();
        FireBow fireBow = FireBowWeapon.GetComponent<FireBow>();

        items = new Item[]
        {
            sword,
            bow,
            fireBow
        };

        SwordWeapon.SetActive(true);
        BowWeapon.SetActive(false);
        FireBowWeapon.SetActive(false);
        currentItem = items[0];
        currentItem.Ready = true;
        canUseWeapon = true;
        
    }

    public void SwitchToSword()
    {
        SwordWeapon.SetActive(true);
        BowWeapon.SetActive(false);
        FireBowWeapon.SetActive(false);
        currentItem.Switch(items[0], 1);
        currentItem = items[0];
        currentItem.Ready = true;
        Debug.Log("Sword selected!");
    }

    public void SwitchToBow()
    {
        SwordWeapon.SetActive(false);
        BowWeapon.SetActive(true);
        FireBowWeapon.SetActive(false);
        currentItem.Switch(items[1], 2);
        currentItem = items[1];
        currentItem.Ready = true;
        Debug.Log("Bow selected!");
    }

    public void SwitchToFireBow()
    {
        SwordWeapon.SetActive(false);
        BowWeapon.SetActive(false);
        FireBowWeapon.SetActive(true);
        currentItem.Switch(items[2], 3);
        currentItem = items[2];
        currentItem.Ready = true;
        Debug.Log("Fire bow selected!");
    }

    public void UseItem()
    {
        // Checking if item can be used / in cooldown
        if (!canUseWeapon || Time.time < currentItem.nextTimeUse)
        {
            Debug.Log("Can't use now.");
            return;
        }
        if (Time.time > currentItem.nextTimeUse)
        {
            currentItem.nextTimeUse = Time.time + currentItem.Cooldown;
            currentItem.Use();
        }
    }
}
