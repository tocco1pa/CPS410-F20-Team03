//////////////////////////////////
//     Author: Helana Brock    //
/////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToForest : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
        	SceneManager.LoadScene("Forest");
        }
    }
}
