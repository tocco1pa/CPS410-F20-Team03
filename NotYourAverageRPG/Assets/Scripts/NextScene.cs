//////////////////////////////////
//     Author: Helana Brock    //
/////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/*
    Attemoted to save player position when going back and forth between scenes using
    PlayerPrefs. This script sends you to different scenes, but does not save state 
    right now; or at least, it doesn't work as expected.
*/
public class NextScene : MonoBehaviour
{

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
    	if (other.gameObject.tag == "Player") {
    		if (PlayerPrefs.HasKey("PlayerX") == true) {
    			other.GetComponent<Rigidbody2D>().MovePosition(new Vector2(x:PlayerPrefs.GetFloat("PlayerX"), y:PlayerPrefs.GetFloat("PlayerY")));
	    		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	    	} else {
    			PlayerPrefs.SetFloat("PlayerX", other.GetComponent<Rigidbody2D>().position.x);
				PlayerPrefs.SetFloat("PlayerY", other.GetComponent<Rigidbody2D>().position.y);
	    	}
    	}
    }
}
