using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoopPortal : MonoBehaviour
{
    public Text portalText;
    private bool loopRunInRange = false;

    public void Start()
    {
        portalText = GetComponentInChildren<Text>();
        portalText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            loopRunInRange = true;
            portalText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            loopRunInRange = false;
            portalText.enabled = false;
        }
    }

    private void Update()
    {
        if (loopRunInRange && Input.GetKey(KeyCode.E))
        {
            ResetScene();
        }
    }

    public void ResetScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
