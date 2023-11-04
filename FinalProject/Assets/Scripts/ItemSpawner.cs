using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Transform[] itemSpawnPoints;
    public List<GameObject> commonItems; // List of common items
    public List<GameObject> uncommonItems; // List of uncommon items
    public List<GameObject> rareItems; // List of rare items
    public List<GameObject> legendaryItems; // List of legendary items

    public int[] itemRarity = 
    { 
        50, // Common
        30, // Uncommon 
        19, // Rare
        1  // Legendary
    };

    public void SpawnItem()
    {
        int randomNum = Random.Range(0, 100);

        if (randomNum < itemRarity[0])
        {
            SpawnRandomItem(commonItems);
        }
        else if (randomNum < itemRarity[0] + itemRarity[1])
        {
            SpawnRandomItem(uncommonItems);
        }
        else if (randomNum < itemRarity[0] + itemRarity[1] + itemRarity[2])
        {
            SpawnRandomItem(rareItems);
        }
        else
        {
            SpawnRandomItem(legendaryItems);
        }
    }

    void SpawnRandomItem(List<GameObject> itemCategory)
    {
        if (itemCategory.Count > 0)
        {
            int randomIndex = Random.Range(0, itemCategory.Count);
            GameObject itemToSpawn = itemCategory[randomIndex];

            if (itemToSpawn != null)
            {
                // Spawn the selected item at a random spawn point
                Transform spawnPoint = itemSpawnPoints[Random.Range(0, itemSpawnPoints.Length)];
                Instantiate(itemToSpawn, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
