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
    public Animator Animator;

    private void Start()
    {
        Sword sword = Instantiate(Resources.Load<Sword>("Prefabs/Items/Weapons/Sword"));
        Bow bow = Instantiate(Resources.Load<Bow>("Prefabs/Items/Weapons/Bow"));
        FireBow fireBow = Instantiate(Resources.Load<FireBow>("Prefabs/Items/Weapons/Fire Bow"));

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
    }

    private void Update()
    {
        //Debug.Log(currentItem);
    }

    public void SwitchToSword()
    {
        SwordWeapon.SetActive(true);
        BowWeapon.SetActive(false);
        FireBowWeapon.SetActive(false);
        currentItem.Switch(items[0], 1);
        currentItem = items[0];
        Debug.Log("Sword selected!");
    }

    public void SwitchToBow()
    {
        SwordWeapon.SetActive(false);
        BowWeapon.SetActive(true);
        FireBowWeapon.SetActive(false);
        currentItem.Switch(items[1], 2);
        currentItem = items[1];
        Debug.Log("Bow selected!");
    }

    public void SwitchToFireBow()
    {
        SwordWeapon.SetActive(false);
        BowWeapon.SetActive(false);
        FireBowWeapon.SetActive(true);
        currentItem.Switch(items[2], 3);
        currentItem = items[2];
        Debug.Log("Fire bow selected!");
    }

    public void UseItem()
    {
        currentItem.Use();
    }
}
