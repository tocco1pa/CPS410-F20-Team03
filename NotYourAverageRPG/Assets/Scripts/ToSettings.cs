//////////////////////////////////
//     Author: Helana Brock    //
/////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToSettings : MonoBehaviour
{
    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
