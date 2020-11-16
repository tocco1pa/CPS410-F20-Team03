using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item 
{
   public enum ItemType
    {
        Sword,
        Spear,
        Bow,
        Arrow,
        Potion,
        Coin,
    }

    public ItemType itemType;
    public int amount;

    public static int GetCost(ItemType itemType)
    {
        switch(itemType)
        {
            default:
            case ItemType.Sword: return 10;
            case ItemType.Spear: return 20;
            case ItemType.Bow: return 15;
            case ItemType.Arrow: return 3;
            case ItemType.Potion: return 7;
            case ItemType.Coin: return 1;
        }
    }

    public Sprite GetSprite() 
    {
        switch (itemType) {
            default:
            case ItemType.Sword:  return ItemAssets.Instance.swordSprite;
            case ItemType.Spear:  return ItemAssets.Instance.spearSprite;
            case ItemType.Bow:    return ItemAssets.Instance.bowSprite;
            case ItemType.Arrow:  return ItemAssets.Instance.arrowSprite;
            case ItemType.Potion: return ItemAssets.Instance.potionSprite;
            case ItemType.Coin:   return ItemAssets.Instance.coinSprite;
        }
    }

    public bool IsStackable() {
        switch (itemType)
        {
            default:
            case ItemType.Sword:
            case ItemType.Spear:
            case ItemType.Bow:
                return false;
            case ItemType.Arrow:
            case ItemType.Potion:
            case ItemType.Coin:
                return true;
        }
    }

}
