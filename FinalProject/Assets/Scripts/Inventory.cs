using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<ItemInv> itemList;

    public Inventory()
    {
        itemList = new List<ItemInv>();
        AddItem(new ItemInv { itemType = ItemInv.ItemType.Bomb, amount = 1 });
    }

    public void AddItem(ItemInv item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<ItemInv> GetItemList()
    {
        return itemList;
    }

}
