/*
*   Author: Phil Tocco
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//interactable script to attach to chests and other interactable objects
public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey; //key on keyboard that interacts with the object
    public UnityEvent interactAction; //interaction that happens on key press
    

    // Update is called once per frame
    void Update()
    {
        if(isInRange) //check of player is in range
        {
            if(Input.GetKeyDown(interactKey)) //if key is pressed, invoke action
            {
                interactAction.Invoke();
                Debug.Log("action taken");
            }
        }
        
    }

    //When player enters the collider, set isInRange to true
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player in range");
        }
    }

     //When palyer exits the collider, set isInRange to false
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player out of range");
        }
    }
}
