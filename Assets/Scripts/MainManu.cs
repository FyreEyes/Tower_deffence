using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainManu : MonoBehaviour
{
    public string levelToLoad = "LevelSelect";

    public SceneFader sceneFader;
    
    public void Play()
    {
       sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }
}
