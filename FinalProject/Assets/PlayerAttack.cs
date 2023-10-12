using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Enemies")
        {
            collision.gameObject.GetComponent<WaveEnemies>().TakeDamage(2);
        }
    }
}
