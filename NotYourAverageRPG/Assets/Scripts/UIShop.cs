/*
 * Author: Patrick Hanrahan
 * Based off of Code Monkey's "Simple shop in Unity"
 * https://www.youtube.com/watch?v=HuXy4XX0hzg
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*  (INCOMPLETE)
 * UI shop script. Makes the shop menu + buttons,
 * as well as making it so that the shop buttons actually do things
 * 
 * Unfortunately, I was not able to make the button functional
 * 
 */
public class UIShop : MonoBehaviour
{
    // Properties of shop button in heirarchy
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;

    // Finds the properties and hides them when the game awakes
    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    // Creates the item buttons when the game starts, and then hides it
    private void Start()
    {
        CreateItemButton(Item.ItemType.Sword, "Sword", Item.GetCost(Item.ItemType.Sword), 0);
        CreateItemButton(Item.ItemType.Spear, "Spear", Item.GetCost(Item.ItemType.Sword), 1);
        CreateItemButton(Item.ItemType.Bow, "Bow", Item.GetCost(Item.ItemType.Sword), 2);
        CreateItemButton(Item.ItemType.Arrow, "Arrow", Item.GetCost(Item.ItemType.Sword), 3);
        CreateItemButton(Item.ItemType.Potion, "Potion", Item.GetCost(Item.ItemType.Sword), 4);

        Hide();
    }

    // Method to create item button by getting item properties
    private void CreateItemButton(Item.ItemType itemType, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        // Button functionality (based off tutorial, had issues getting button to work)
        //                                 v Button script that wasn't shown in tutorial
        /* shopItemTransform.GetComponent<Button_UI>().ClickFunc = () =>
         * {
         *    TryBuyItem(itemType);
         * }
         */
    }

    // Using the shopCustomer interface, items are bought
    private void TryBuyItem(Item.ItemType itemType)
    {
        shopCustomer.BoughtItem(itemType);
    }

    // Shows the shop menu
    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    // Hides the shop menu
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
