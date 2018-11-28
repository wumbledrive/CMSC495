using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inventory keeps track of each item in the inventory
public class Inventory : MonoBehaviour
{
    //A list of items, their slots, and the parent of each item
    [SerializeField] List<Item> items;
    [SerializeField] Transform parent;
    [SerializeField] ItemSlots[] slots;

    //OnValidate is called when script is loaded or value is changed
    private void OnValidate()
    {
        if (parent != null)
            slots = parent.GetComponentsInChildren<ItemSlots>();
        RefreshUI();
    }

    //Refreshes the UI so that items appear/disappear from inventory
    private void RefreshUI()
    {
        int i = 0;
        //For every item, assign it to an item slot
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].Item = items[i];
        }

        //For the remaining empty slots, the item is null
        for (; i < slots.Length; i++)
        {
            slots[i].Item = null;
        }
    }

    //Adds an item to the inventory
    public bool AddItem(Item item)
    {
        //If the inventory is full, don't add the item
        if (items.Count >= slots.Length)
            return false;

        //Add the item and refresh the UI
        items.Add(item);
        RefreshUI();
        return true;
    }

    //Removes an item from the inventory
    public bool RemoveItem(Item item)
    {
        //If the item given can be removed, remove it and refresh the UI
        if (items.Remove(item))
        {
            RefreshUI();
            return true;
        }
        return false;
    }
}
