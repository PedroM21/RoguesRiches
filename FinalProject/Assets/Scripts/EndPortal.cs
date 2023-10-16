using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPortal : MonoBehaviour
{
    public Text portalText;
    private bool endRunInRange = false;

    public void Start()
    {
        portalText = GetComponentInChildren<Text>();
        portalText.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            endRunInRange = true;
            portalText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            endRunInRange = false;
            portalText.enabled = false;
        }
    }

    private void Update()
    {
        if (endRunInRange && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("EndRunScene");
        }
    }
}
