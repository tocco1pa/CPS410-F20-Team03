//////////////////////////////////
//     Author: Helana Brock    //
/////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private bool paused = false;
    public Canvas settings;

    void Start() {
        settings.enabled = false;
    }

    public void StartGame() {
    	SceneManager.LoadScene("Forest");
    }

    public void ReloadLevel() {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
    	SceneManager.LoadScene("MainMenu");
    }

    public void Settings() { // Toggle being paused.
        if (paused)
        {
            settings.enabled = false;
            Time.timeScale = 1;
        }
        else
        {
            settings.enabled = true;
            Time.timeScale = 0;
        }
    }

    public void QuitGame() {
    	Application.Quit();
    }
}
