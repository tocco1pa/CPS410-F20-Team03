/*
 * Author: Patrick Hanrahan
 * Based off of Code Monkey's "Simple shop in Unity"
 * https://www.youtube.com/watch?v=HuXy4XX0hzg
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Script for the shop trigger area. when a customer enters the ares,
 * the shop will pop up on screen
 */
public class ShopTriggerCollider: MonoBehaviour
{
    // uiShop instance for the script to use
    [SerializeField] private UIShop uiShop;

    // Shows the menu when the trigger area is entered
    private void OnTriggerEnter2D(Collider2D collider)
    {
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        if(shopCustomer != null)
        {
            uiShop.Show(shopCustomer);
        }
    }

    // Hides the menu when the trigger area is exited
    private void OnTriggerExit2D(Collider2D collider)
    {
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        if (shopCustomer != null)
        {
            uiShop.Hide();
        }
    }
}
