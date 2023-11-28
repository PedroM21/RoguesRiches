using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInv
{
    public enum ItemType
    {
        Syringe,
        Scope,
        Tear,
        Bomb,
        Dart,
        Hammer,
        Clock,
        Dice

    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Syringe:
                return ItemAssets.Instance.syringeSprite;
            case ItemType.Tear:
                return ItemAssets.Instance.tearSprite;
            case ItemType.Scope:
                return ItemAssets.Instance.scopeSprite;
            case ItemType.Bomb:
                return ItemAssets.Instance.bombSprite;
            case ItemType.Dart:
                return ItemAssets.Instance.dartSprite;
            case ItemType.Hammer:
                return ItemAssets.Instance.hammerSprite;
            case ItemType.Clock:
                return ItemAssets.Instance.clockSprite;
            case ItemType.Dice:
                return ItemAssets.Instance.diceSprite;
        }
    }

}
