using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]

public class Perry
{
    public string WaveName;
    public int NoOfEnemies;
    public GameObject[] TypeOfEnemies;
    public float SpawnInterval;
}

public class PerrySpawner : MonoBehaviour
{
    public Wave[] Waves;
    public Transform[] SpawnPoints;
    public Text waveName;
    public Text score;
    public Text deathno;
    public Text points;
    public GameObject ScoreText;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;
    public Enemy enemy;
    public int Deaths;
    public int Points;

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
        score.text = ("You survived till " + waveName.text);
        deathno.text = ("Enemies killed: " + Deaths);
        points.text = ("Final Score: " + Points);

    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.TypeOfEnemies[Random.Range(0, currentWave.TypeOfEnemies.Length)];
            Transform randomPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            //randomEnemy.GetComponent<Enemy>().kills = this;
            currentWave.NoOfEnemies--;
            nextSpawnTime = Time.time + currentWave.SpawnInterval;
            if (currentWave.NoOfEnemies == 0)
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
