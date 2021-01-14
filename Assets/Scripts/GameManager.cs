using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    
    public GameObject endGameUI;
    public GameObject completeLevelUI;

    private void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;
        //pause menu?
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     EndGame();
        // }
        
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        GameIsOver = true;
        endGameUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
