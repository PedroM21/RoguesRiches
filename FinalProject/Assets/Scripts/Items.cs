using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] GameObject[] commonItems;
    [SerializeField] GameObject[] unCommonItems;
    [SerializeField] GameObject[] rareItems;
    [SerializeField] GameObject[] legendaryItems;

    [SerializeField] float commonSpawnRate = 0.5f;
    [SerializeField] float unCommonSpawnRate = 0.3f;
    [SerializeField] float rareSpawnRate = 0.19f;
    [SerializeField] float legendarySpawnRate = 0.01f;

    public GameObject SelectItem()
    {
        GameObject[] itemOptions = new GameObject[4];

        itemOptions[0] = commonItems[Random.Range(0, commonItems.Length)];

        itemOptions[1] = unCommonItems[Random.Range(0, unCommonItems.Length)];

        itemOptions[2] = rareItems[Random.Range(0, rareItems.Length)];

        itemOptions[3] = legendaryItems[Random.Range(0, legendaryItems.Length)];

        GameObject randomItem = itemOptions[Random.Range(0, itemOptions.Length)];

        

        Debug.Log("Items spawned");
        return randomItem;
    }
}
