/*
 * Author: Patrick Hanrahan
 * Based off of Code Monkey's "Simple shop in Unity"
 * https://www.youtube.com/watch?v=HuXy4XX0hzg
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Interface for shop customer
 */

// Method(s) for customers to use to buy items
public interface IShopCustomer
{
    void BoughtItem(Item.ItemType itemType);
}
