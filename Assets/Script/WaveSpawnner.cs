﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]

public class Wave
{
    public string WaveName;
    public int NoOfEnemies;
    public GameObject[] TypeOfEnemies;
    public float SpawnInterval;
}

public class WaveSpawnner : MonoBehaviour
{
    public Wave[] Waves;
    public Transform[] SpawnPoints;
    public Text waveName;
    public Text score;
    public GameObject ScoreText;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;

    private void Update()
    {
        currentWave = Waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0 && !canSpawn)
            if (currentWaveNumber + 1 != Waves.Length)
            {
                {
                    waveName.text = Waves[currentWaveNumber + 1].WaveName;
                    currentWaveNumber++;
                    canSpawn = true;
                }
            }
        score.text = ("You survived till  " + waveName.text);

    }

    void SpawnWave()
    {
        if(canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.TypeOfEnemies[Random.Range(0, currentWave.TypeOfEnemies.Length)];
            Transform randomPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.NoOfEnemies--;
            nextSpawnTime = Time.time + currentWave.SpawnInterval;
            if(currentWave.NoOfEnemies == 0)
            {
                canSpawn = false;
            }
        }

    }

    private void Awake()
    {
        
        DontDestroyOnLoad(ScoreText);

    }

}
