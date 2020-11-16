/*
*   Author: Phil Tocco
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inventory object that holds items that have been picked up
public class Inventory
{

    public event EventHandler OnItemListChanged; //event for when the item list changes
   public List<Item> itemList; //list of items in inventory

    //constructor
   public Inventory()
   {
       itemList = new List<Item>();
   }

    //add an item to the inventory
   public void AddItem(Item item) {
       if(item.IsStackable()) //check if the item is stackable
       {
           bool itemAlreadyInInventory = false;
           foreach (Item inventoryItem in itemList)
           {
               if(inventoryItem.itemType == item.itemType) //if item already exists in inventory, add to its amount
               {
                   inventoryItem.amount += item.amount;
                   itemAlreadyInInventory = true;
               }
           }
           if(!itemAlreadyInInventory) //if the item hasn't been picked up yet, create a new item
           {
                itemList.Add(item);

           }
       }else { //if not stackable, add item to inventory
       itemList.Add(item); 

       }
       OnItemListChanged?.Invoke(this, EventArgs.Empty); //when the list changes, refresh the UI
   }

    //returns the item list for use in other classes
   public List<Item> GetItemList()
   {
       return itemList;
   }
}
