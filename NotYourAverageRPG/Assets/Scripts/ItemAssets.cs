using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite swordSprite;
    public Sprite spearSprite;
    public Sprite bowSprite;
    public Sprite arrowSprite;
    public Sprite potionSprite;
    public Sprite coinSprite;
}
