/*
*   Author: Phil Tocco
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//the UI object to display the inventory
public class UI_Inventory : MonoBehaviour
{
   private Inventory inventory;
   private Transform itemSlotContainer;
   private Transform itemSlotTemplate;
   public bool showHide = false; //set the UI to hidden as default
   

   
   //on start, locate the itemSlotContainer and the template. Set the UI to inactive
   private void Awake()
   {
       itemSlotContainer = transform.Find("ItemSlotContainer");
       itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
       gameObject.SetActive(false);
   }

    //Show or hide the UI on key press
    public void showHideUI() {
        if(showHide == true) {
            showHide = false;
            gameObject.SetActive(false);
        }
        else if(showHide == false) {
            showHide = true;
            gameObject.SetActive(true);

        }
    }

    //Set what items are in the inventory initially and refresh the UI elements
   public void SetInventory(Inventory inventory)
   {
       this.inventory = inventory;
       inventory.OnItemListChanged += Inventory_OnItemListChanged;
       RefreshInventoryItems();
   }

    //When an item is added or subtracted from the inventory, refresh the UI elements
   private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
   {
       RefreshInventoryItems();
   }

    //refresh the UI elements to show items in inventory
   private void RefreshInventoryItems()
   {
       foreach (Transform child in itemSlotContainer) 
       {
           if(child == itemSlotTemplate) continue; //delete the template from view
           Destroy(child.gameObject);
       }
       int x = 0; //columns of the UI
       int y = 0; //rows of the UI
       float itemSlotCellSize = 90f; //spacing between each element
       foreach (Item item in inventory.GetItemList()) //for each item in the inventory
       {
           //create a copy of the itemSlotTemplate
           RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>(); 
            itemSlotRectTransform.gameObject.SetActive(true);

            //move the item slot to the correct position in the Inventory UI
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            //display the item's sprite
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            //display the item's amount as text
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            
            if(item.amount > 1) //if the item is stackable and the amount is greater than one, show the amount
            {
            uiText.SetText(item.amount.ToString());
            } else //if the item is not stackable or only one exists, don't show amount text
            {
                uiText.SetText("");
            }

            x++; //when an item is placed in the UI, move to the next column
            if(x > 3) //when the last item that can fit in the row is placed, move to the next row
            {
                x = 0;
                y--;
            }
       }
   }
}
