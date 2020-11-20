/*
 * Author: Patrick Hanrahan
 * Based off of Code Monkey's "Simple shop in Unity"
 * https://www.youtube.com/watch?v=HuXy4XX0hzg
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Item assets script to store item script
 */
public class ItemAssets : MonoBehaviour
{
    // Instance of the item assets 
    public static ItemAssets Instance { get; private set; }

    // Starts the instance when the game starts
    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    // List of item sprites
    public Sprite swordSprite;
    public Sprite spearSprite;
    public Sprite bowSprite;
    public Sprite arrowSprite;
    public Sprite potionSprite;
    public Sprite coinSprite;
}
