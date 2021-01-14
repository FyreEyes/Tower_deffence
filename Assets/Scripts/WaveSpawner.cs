using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public GameManager gameManager;
    
    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;
    
    
    public Text waveCountdownText;
    
    public float wavesCd = 5f;
    private float countdown = 2f;
    
    private int waveIndex = 0;
    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = wavesCd;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }

        waveIndex++;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
