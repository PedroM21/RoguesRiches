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
    public bool isBossWave;
}
public class WaveSpawner : MonoBehaviour
{
    public enum GameState { SpawningWave, ItemSelection, WaveCompleted }

    [SerializeField] Wave[] waves;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform[] portalSpawnPoints;
    [SerializeField] Items items;
    [SerializeField] GameObject loopPortal;
    [SerializeField] GameObject endPortal;
    public GameState gameState;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;
    private bool spawnedPortals = false;

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
                break;

            case GameState.ItemSelection:
                if (items != null)
                {
                    Debug.Log("In Item Selection State");
                    GameObject selectedItem = items.SelectItem();

                    //currentWaveNumber++;
                    //canSpawn = true;
                    gameState = GameState.WaveCompleted;
                }
                break;
            
            case GameState.WaveCompleted:
                if (items != null)
                {
                    Debug.Log("Wave Completed State");
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
                            Debug.Log("Wave's ended, Spawn both loop portal and end run portal!!");
                            SpawnPortals();
                            spawnedPortals = true;
                        }
                        
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
            else
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
            Debug.LogError("Please assign at least 2 points!");
        }
        
    }

}
