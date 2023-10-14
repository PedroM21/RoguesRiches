using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string waveName;
    public int numOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}
public class WaveSpawner : MonoBehaviour
{
    public enum GameState { SpawningWave, ItemSelection, WaveCompleted }

    [SerializeField] Wave[] waves;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Items items;
    public GameState gameState;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;

    private void Start()
    {
        gameState = GameState.SpawningWave;
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.SpawningWave:
                Debug.Log("Spawning wave state");
                currentWave = waves[currentWaveNumber];
                SpawnWave();
                CheckWaveCompletion();
                break;

            case GameState.ItemSelection:
                if (items != null)
                {
                    Debug.Log("In Item Selection State");
                    GameObject selectedItem = items.SelectItem();

                    currentWaveNumber++;
                    canSpawn = true;
                    gameState = GameState.SpawningWave;
                }
                break;
            
            case GameState.WaveCompleted:
                if (items != null && items.SelectItem())
                {
                    Debug.Log("Wave Completed State");
                    currentWaveNumber++;
                    canSpawn = true;
                    gameState = GameState.SpawningWave;
                }
                break;
        }

    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        { 
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.numOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.numOfEnemies == 0)
            {
                canSpawn = false;
            }

        }
    }

    void CheckWaveCompletion()
    {
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemies");
        if (totalEnemies.Length == 0 && !canSpawn)
        {
            gameState = GameState.ItemSelection;
        }
    }

}
