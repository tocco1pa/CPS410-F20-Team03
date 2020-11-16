//////////////////////////////////
//     Author: Helana Brock    //
/////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*
    Attach this to ANY NPC you want to display text.
    Make sure it has a collider with isTrigger checked.
    Then, when player is in range it will display any
    text you attach to your object.

    This is the same as signs, just with a different 
    name for organization.
*/
public class Dialogue : MonoBehaviour
{
    public Text dialogue;

    void Start() {
    	dialogue.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other) {
    	if (other.gameObject.tag == "Player") {
    		dialogue.enabled = true;
    	}
    }

    public void OnTriggerExit2D(Collider2D other) {
    	if (other.gameObject.tag == "Player") {
    		dialogue.enabled = false;
    	}
    }
}
