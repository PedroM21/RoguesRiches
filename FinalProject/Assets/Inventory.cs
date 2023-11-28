using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<ItemInv> itemList;

    public Inventory()
    {
        itemList = new List<ItemInv>();
        AddItem(new ItemInv { itemType = ItemInv.ItemType.Bomb, amount = 1 });
        AddItem(new ItemInv { itemType = ItemInv.ItemType.Syringe, amount = 1 });
        AddItem(new ItemInv { itemType = ItemInv.ItemType.Tear, amount = 1 });
        AddItem(new ItemInv { itemType = ItemInv.ItemType.Hammer, amount = 1 });
        AddItem(new ItemInv { itemType = ItemInv.ItemType.Scope, amount = 1 });
        AddItem(new ItemInv { itemType = ItemInv.ItemType.Dart, amount = 1 });
        AddItem(new ItemInv { itemType = ItemInv.ItemType.Dice, amount = 1 });
        AddItem(new ItemInv { itemType = ItemInv.ItemType.Clock, amount = 1 });
    }

    public void AddItem(ItemInv item)
    {
        itemList.Add(item);
    }

    public List<ItemInv> GetItemList()
    {
        return itemList;
    }

}
