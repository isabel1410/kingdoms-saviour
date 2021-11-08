using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private string SoldOutItemResourcePath;

    public string MerchantName;
    public PlayerItems PlayerItems;
    public ShopView ShopView;
    public GameObject[] Items; //Consists of Weapons, Potions and Armor
    public GameObject[] ShelfItems;
    public GameObject[] ShelfItemsOutOfStock;
    public UnityEngine.Events.UnityEvent<bool> ToggleShopEvent;

    // Start is called before the first frame update
    private void Start()
    {
        for (byte counter = 0; counter < Items.Length; counter++)
        {
            Item item = Items[counter].GetComponent<Item>();
            if (PlayerItems.Items.Contains(item))
            {
                //Potions are stackable, other items are not
                if (item is Potion potion)
                {
                    Potion playerPotion = (Potion)PlayerItems.Items.Where(playerPotion => playerPotion.GetType() == potion.GetType()).First();
                    if (playerPotion.Amount < potion.Capacity)
                    {
                        continue;
                    }
                }

                Items[counter] = Resources.Load<GameObject>(SoldOutItemResourcePath);
                ShelfItemsOutOfStock[counter].SetActive(true);
                ShelfItems[counter].SetActive(false);
            }
        }
        /*
        foreach (Item item in AllItems.Select(item => item.GetComponent<Item>()))
        {
            Debug.Log($"{item.GetType()} available in shop: {item.AvailableInShop}");
        }*/
        //EnterShop();
    }

    public void EnterShop()
    {
        ToggleShopEvent.Invoke(true);
        RunDialogue("Welcome to the shop loser!");
    }

    public void ExitShop()
    {
        ToggleShopEvent.Invoke(false);
    }

    public void PurchaseItem(int itemIndex)
    {
        Item item = Items[itemIndex].GetComponent<Item>();

        //Check if this line of items is sold out
        if (item is SoldOutItem)
        {
            RunDialogue("I'm afraid I don't have that item in stock anymore.");
            return;
        }

        //Check if the player has enough gold
        if (PlayerItems.Gold < item.Price)
        {
            RunDialogue("You don't have enough gold to purchase " + item.name + ".");
            return;
        }

        PlayerItems.Gold -= item.Price;
        PlayerItems.Items.Add(item);
        RunDialogue("Thank you for your purchase!");

        for (int counter = 0; counter < Items.Length; counter++)
        {
            if (Items[counter].GetComponent<Item>() == item)
            {
                if (item is Potion potion)
                {
                    Potion playerPotion = (Potion) PlayerItems.Items.Where(item => item.GetType() == potion.GetType()).FirstOrDefault();
                    playerPotion.Amount++;
                    if (playerPotion.Amount == playerPotion.Capacity)
                    {
                        Items[counter] = Resources.Load<GameObject>(SoldOutItemResourcePath);
                        ShelfItemsOutOfStock[counter].SetActive(true);
                        ShelfItems[counter].SetActive(false);
                    }
                }
                else
                {
                    Items[counter] = Resources.Load<GameObject>(SoldOutItemResourcePath);
                    ShelfItemsOutOfStock[counter].SetActive(true);
                    ShelfItems[counter].SetActive(false);
                }
                counter = Items.Length;//Item found, end loop
            }
        }

        Debug.Log("Purchase succesful");
    }

    private void RunDialogue(string dialogue)
    {
        if (dialogue.Length > 150)
        {
            Debug.LogWarning("Dialogue is too long: 150 characters max, current length: " + dialogue.Length);
        }
        ShopView.RunDialogue(MerchantName, dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnterShop();
        }
    }
}
