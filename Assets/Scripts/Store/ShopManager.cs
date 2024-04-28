using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] public int[,] shopItems = new int[4, 3]; // [ID, ItemID, Price
    [SerializeField] public float coins;
    [SerializeField] public TextMeshProUGUI coinsText;

    // Buttons
    [Header("Buttons")]
    [SerializeField] public Button[] buttons;

    // Items To Buy
    [Header("Items")]
    [SerializeField] public Item WheatSeeds;
    [SerializeField] public Item TomateSeeds;

    public InventoryManager inventoryManager;

    private void Start()
    {
        coinsText.text = coins.ToString();

        // ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;

        // Prices
        shopItems[2, 1] = 15;
        shopItems[2, 2] = 20;

        for (int i = 0; i < buttons.Length; i++)
        {
            int itemID = i + 1;
            buttons[i].onClick.AddListener(() => BuyItem(itemID));
        }
    }

    public void BuyItem(int itemID)
    {
        if (coins >= shopItems[2, itemID])
        {
            coins -= shopItems[2, itemID];
            shopItems[3, itemID]++;
            coinsText.text = coins.ToString();

            switch (itemID)
            {
                case 1:
                    inventoryManager.Add("Hotbar", WheatSeeds);
                    break;
                case 2:
                    inventoryManager.Add("Hotbar", TomateSeeds);
                    break;
            }
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }

    public Item SellItem()
    {
        // get the item from the selected slot

        return null;

    }

}
