using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite syringeSprite;
    public Sprite scopeSprite;
    public Sprite tearSprite;
    public Sprite dartSprite;
    public Sprite bombSprite;
    public Sprite clockSprite;
    public Sprite hammerSprite;
    public Sprite diceSprite;
    
}
