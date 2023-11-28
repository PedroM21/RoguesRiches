using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBarSlider;
    public Text healthBarValue;
    public GameObject gameOverUI;

    public int maxHealth;
    public int currHealth;

    // Sets players health to the max value
    void Start()
    {
        currHealth = maxHealth;
        gameOverUI.SetActive(false);
    }

    // Sets the health bar text to the max amount
    void Update()
    {
        healthBarValue.text = currHealth.ToString() + "/" + maxHealth.ToString();

        healthBarSlider.value = currHealth;
        healthBarSlider.maxValue = maxHealth;
    }

    // Function for taking health off the player's health bar
    public void TakeDamage(int amount)
    {
        currHealth -= amount;
        if (currHealth <= 0)
        {
            healthBarSlider.value = 0;
            healthBarValue.text = "0" + "/" + maxHealth.ToString();
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
            //gameOverUI.SetActive(true);
        }
    }

    public void RetryGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
