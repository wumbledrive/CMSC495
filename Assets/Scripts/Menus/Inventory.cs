using System;
using System.Collections.Generic;
using UnityEngine;

//Inventory keeps track of each item in the inventory
public class Inventory : MonoBehaviour
{
    //A list of items, their slots, and the parent of each item
    [SerializeField] List<Item> startingItems;
    [SerializeField] Transform parent;
    [SerializeField] ItemSlots[] slots;

    public event Action<Item> ItemClickedEvent;

    private void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].LeftClickEvent += ItemClickedEvent;
        }

        SetStartingItems();
    }

    //OnValidate is called when script is loaded or value is changed
    private void OnValidate()
    {
        if (parent != null)
            slots = parent.GetComponentsInChildren<ItemSlots>();

        SetStartingItems();
    }

    //Refreshes the UI so that items appear/disappear from inventory
    private void SetStartingItems()
    {
        int i = 0;
        //For every item, assign it to an item slot
        for (; i < startingItems.Count && i < slots.Length; i++)
        {
            slots[i].Item = startingItems[i].GetCopy();
            slots[i].Amount = 1;
        }

        //For the remaining empty slots, the item is null
        for (; i < slots.Length; i++)
        {
            slots[i].Item = null;
            slots[i].Amount = 0;
        }
    }

    //Adds an item to the inventory
    public bool AddItem(Item item)
    {
        //If the inventory is full, don't add the item
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item == null || (slots[i].Item.ID == item.ID && slots[i].Amount < item.MaximumStack))
            {
                slots[i].Item = item;
                slots[i].Amount++;
                return true;
            }
        }
        return false;
    }

    //Removes an item from the inventory
    public bool RemoveItem(Item item)
    {
        //If the item given can be removed, remove it
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item == item)
            {
                slots[i].Amount--;
                if (slots[i].Amount == 0)
                    slots[i].Item = null;
                return true;
            }
        }
        return false;
    }

    public Item RemoveItem(string itemID)
    {
        //If the item given can be removed, remove it
        for (int i = 0; i < slots.Length; i++)
        {
            Item item = slots[i].Item;
            if (item != null && item.ID == itemID)
            {
                slots[i].Amount--;
                if (slots[i].Amount == 0)
                    slots[i].Item = null;
                return item;
            }
        }
        return null;
    }

    public bool IsFull()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item == null)
            {
                return false;
            }
        }
        return true;
    }

    public int ItemCount(string itemID)
    {
        int count = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item.ID == itemID)
            {
                count++;
            }
        }
        return count;
    }
}
