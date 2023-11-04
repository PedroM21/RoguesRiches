using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public string waveName;
    public int numOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
    public bool isBossWave;
}
public class WaveSpawner : MonoBehaviour
{
    public enum GameState { SpawningWave, ItemSelection, WaveCompleted }

    [SerializeField] Wave[] waves;
    [SerializeField] ItemSpawner itemSpawner;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform[] portalSpawnPoints;
    [SerializeField] bool selectedItem = false;
    [SerializeField] GameObject loopPortal;
    [SerializeField] GameObject endPortal;
    [SerializeField] Text waveCounterText;
    
    public GameState gameState;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;
    private bool spawnedPortals = false;
    private bool alreadySpawned = false;

    private void Start()
    {
        gameState = GameState.SpawningWave;
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.SpawningWave:
                currentWave = waves[currentWaveNumber];
                SpawnWave();
                CheckWaveCompletion();

                if(currentWaveNumber == waves.Length - 1)
                {
                    waveCounterText.text = "Boss Wave";
                }
                else
                    waveCounterText.text = "Wave: " + (currentWaveNumber + 1);

                break;

            case GameState.ItemSelection:
                if (itemSpawner != null)
                {
                    //Debug.Log("In Item Selection State");
                    // Need to add ability for wave to wait until player selects an item
                    // and then moves on to the next wave
                    if (alreadySpawned)
                    {
                        gameState = GameState.ItemSelection;
                    }
                    else
                    {
                        itemSpawner.SpawnItem();
                        HasSpawned();
                    }

                    if (selectedItem)
                    {
                        gameState = GameState.WaveCompleted;
                        alreadySpawned = false;
                        selectedItem = false;
                    }
                    else
                    {
                        gameState = GameState.ItemSelection;
                    }
                    
                }
                break;
            
            case GameState.WaveCompleted:
                currentWaveNumber++;

                if(currentWaveNumber < waves.Length)
                {
                    canSpawn = true;
                    gameState = GameState.SpawningWave;
                }
                else
                {
                    if (!spawnedPortals)
                    {
                        SpawnPortals();
                        spawnedPortals = true;
                    }
                    
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
            if (currentWave.isBossWave)
            {
                SpawnWave();
            }
            else if (itemSpawner != null)
            {
                gameState = GameState.ItemSelection;
            }
            
        }
    }

    public void SpawnPortals()
    {
        if(portalSpawnPoints.Length >= 2)
        {
            Transform loopPortalPoint = portalSpawnPoints[0];
            Transform endPortalPoint = portalSpawnPoints[1];

            Instantiate(loopPortal, loopPortalPoint.position, loopPortalPoint.rotation);
            Instantiate(endPortal, endPortalPoint.position, endPortalPoint.rotation);
        }
        else
        {
            Debug.LogError("Assign 2 points for the portals");
        }
        
    }

    public void HasSpawned()
    {
        alreadySpawned = true;
    }

    public void HasSelectedItem()
    {
        selectedItem = true;
    }
}
