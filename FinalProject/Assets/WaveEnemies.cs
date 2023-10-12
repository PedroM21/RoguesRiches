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

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Debug.Log("Collison with player deteted!");
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);

        }
    }

}
