using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;
    public Text moneyText;

    public static int Rounds;
    
    public static int Lives;
    public int startLives = 20;
    public Text livesText;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();

        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
        livesText.text = Lives + " LIVES";

    }

    // remove lives, form lives script import leves text change
    public void RemoveLife()
    {
        if (GameManager.GameIsOver)
            return;
        
        Lives --;
        livesText.text = Lives + " LIVES";

        if (Lives <= 0)
        {
            gameManager.EndGame();
        }
    }

    // add/reomove money 
    public void AddMoney(int amout) 
    { 
        Money += amout;
        moneyText.text = "$" + Money;
    }
    public void RemoveMoney(int amout)
    {
        Money -= amout;
        moneyText.text = "$" + Money;
    }

    // track rounds survived 
}
