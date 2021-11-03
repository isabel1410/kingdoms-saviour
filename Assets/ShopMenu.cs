using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public string MerchantName;
    public PlayerItems PlayerItems;
    public ShopView ShopView;
    public List<GameObject> AllItems; //Consists of Weapons, Potions and Armor

    // Start is called before the first frame update
    private void Start()
    {
        foreach (GameObject ItemObject in AllItems)
        {
            Item item = ItemObject.GetComponent<Item>();
            if (PlayerItems.Items.Contains(item))
            {
                //Potions are stackable, other items are not
                if (item is Potion potion)
                {
                    Potion playerPotion = (Potion)PlayerItems.Items.Where(playerPotion => playerPotion.GetType() == potion.GetType()).First();
                    if (playerPotion.Amount >= potion.Capacity)
                    {
                        continue;
                    }
                }

                item.AvailableInShop = false;
            }
        }
/*
        foreach (Item item in AllItems.Select(item => item.GetComponent<Item>()))
        {
            Debug.Log($"{item.GetType()} available in shop: {item.AvailableInShop}");
        }*/
    }

    public void TestDialogue()
    {
        string dialogue;
        //dialogue = "WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW";
        dialogue = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla...";
        RunDialogue(dialogue);
    }

    public void PurchaseItem(Item item)
    {
        //Check if this line of items is sold out
        if (!item.AvailableInShop)
        {
            RunDialogue("You already have this item in your inventory.");
            return;
        }

        //Check if the player has enough gold
        if (PlayerItems.Gold < item.Price)
        {
            RunDialogue("You don't have enough gold to purchase " + item.name + ".");
            return;
        }

        PlayerItems.Items.Add(item);
        item.AvailableInShop = false;
        RunDialogue("Thank you for your purchase!");
    }

    private void RunDialogue(string dialogue)
    {
        if (dialogue.Length > 150)
        {
            Debug.LogWarning("Dialogue is too long: 150 characters max, current length: " + dialogue.Length);
        }
        ShopView.RunDialogue(MerchantName, dialogue);
    }
}
