/*
*   Author: Phil Tocco
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controller function connected to the chest that allows it to be opened and spawn items from spawners
public class ChestController : MonoBehaviour
{
    public bool isOpen;
    public List<ItemWorldSpawner> spawners = new List<ItemWorldSpawner>(); //list of spawners attatched to the chest in Unity


    public void OpenChest()
    {
        if(!isOpen) //if chest is closed, open it. Only works once
        {
            isOpen = true;
            foreach (ItemWorldSpawner spawner in spawners)
            {
                spawner.spawnItem(); //spawn items
            }
        }
    }     
}
