using System;
using System.Collections; //idk what these are for, but the youtube
using System.Collections.Generic; //tutorial had these
using UnityEngine;
using UnityEngine.SceneManagement; //scene1 - mainMenu; scene2 - settings; scene 3 - game;
public class ButtonPressed : MonoBehaviour
{
    public void ToSettings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //goes to scene2
        //assuming we put the settings thingy to scene 2
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //goes back to scene1
        //assuming the settings is in scene 2, we're going back to scene 1 (main menu)
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //goes to scene 3
        //assuming game takes place in scene 3
    }
}