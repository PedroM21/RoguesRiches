using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    private bool inRange = false;
    private WaveSpawner waveSpawner;

    private void Start()
    {
        waveSpawner = GameObject.FindObjectOfType<WaveSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("Player entered the interaction range.");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            Debug.Log("Player exited the interaction range.");
        }
    }

    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            // Add item logic here, ideally add it to an inventory so player can see items in possession
            if (waveSpawner != null)
            {
                waveSpawner.HasSelectedItem();
            }
            Destroy(gameObject);
        }
    }
}
