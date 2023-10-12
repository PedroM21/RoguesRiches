using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBarSlider;
    public Text healthBarValue;

    public int maxHealth;
    public int currHealth;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarValue.text = currHealth.ToString() + "/" + maxHealth.ToString();

        healthBarSlider.value = currHealth;
        healthBarSlider.maxValue = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currHealth -= amount;
        if (currHealth <= 0)
        {
            healthBarSlider.value = 0;
            healthBarValue.text = "0" + "/" + maxHealth.ToString();
            Destroy(gameObject);
        }
    }

}
