using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;
    
    public string manuSceneName = "MainManu";
    
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public void Contrinue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(manuSceneName);
    }
    
}
