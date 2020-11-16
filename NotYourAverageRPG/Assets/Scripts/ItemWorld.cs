/*
*   Author: Phil Tocco
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ItemWorld object that holds the items that spawn in the world
public class ItemWorld : MonoBehaviour
{
    //spawn a specified item in the world at a specified position
    public static ItemWorld SpawnItemWorld(Vector2 position, Item item) 
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity); //spawn the item
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item); //get the sprite and other properties of the item

        return itemWorld;
    }
    private Item item;
    private SpriteRenderer spriteRenderer;

    //on start, render the item's sprite
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    //set the properties of an item
    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    //access an item
    public Item GetItem() 
    {
        return item;
    }

    //destroy the item when it is picked up or used
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
