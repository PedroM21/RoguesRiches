using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 9f;
    private float lowerBound = -9f;
    private float leftBound = -15f;
    private float rightBound = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the object exits the players view. Remove that object
        if (transform.position.y > topBound || transform.position.y < lowerBound || transform.position.x < leftBound || transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }
}
