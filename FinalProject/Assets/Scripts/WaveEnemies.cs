using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemies : MonoBehaviour
{
    public int maxHealth = 6;
    public int currentHealth;
    public int damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Function to calculate damage taken
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // If player collides with enemy, the player will take damage.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

}
