//////////////////////////////////
//     Author: Helana Brock    //
/////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*
    Attach this to ANY object you want to display text.
    Make sure it has a collider with isTrigger checked.
    Then, when player is in range it will display any
    text you attach to your object.
*/
public class Signs : MonoBehaviour
{
	public Text sign;

	void Start() 
	{
		sign.enabled = false;
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
    	if (other.gameObject.tag == "Player")
    	{
    		sign.enabled = true;
    	}
    }

    public void OnTriggerExit2D(Collider2D other)
    {
    	if (other.gameObject.tag == "Player")
    	{
    		sign.enabled = false;
    	}
    }
}
