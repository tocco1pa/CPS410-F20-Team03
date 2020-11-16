/*
*   Author: Phil Tocco
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawner object used to spawn items in the world. Attatched to spawner prefabs
public class ItemWorldSpawner : MonoBehaviour {

    public Item item;
    public bool spawnAtStart = false; //choose if the item should spawn in the world naturally or through a trigger
    //on start, spawn the item if spawnAtStart is true
    private void Start() {
        if(spawnAtStart == true)
        {
            spawnItem();
        }
    }

    //spawn the specified item at the spawner's location
    public void spawnItem() 
    {
        ItemWorld.SpawnItemWorld(transform.position, item);
        Destroy(gameObject);    
    }

}
