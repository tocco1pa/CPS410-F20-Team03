using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateItemButton(Item.ItemType.Sword, "Sword", Item.GetCost(Item.ItemType.Sword), 0);
        CreateItemButton(Item.ItemType.Spear, "Spear", Item.GetCost(Item.ItemType.Sword), 1);
        CreateItemButton(Item.ItemType.Bow, "Bow", Item.GetCost(Item.ItemType.Sword), 2);
        CreateItemButton(Item.ItemType.Arrow, "Arrow", Item.GetCost(Item.ItemType.Sword), 3);
        CreateItemButton(Item.ItemType.Potion, "Potion", Item.GetCost(Item.ItemType.Sword), 4);

        Hide();
    }

    private void CreateItemButton(Item.ItemType itemType, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.GetComponent<Button>();
            TryBuyItem(itemType);

    }

    private void TryBuyItem(Item.ItemType itemType)
    {
        shopCustomer.BoughtItem(itemType);
    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
