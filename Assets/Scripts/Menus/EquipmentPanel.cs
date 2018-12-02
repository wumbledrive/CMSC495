using System;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour {

    [SerializeField] Transform parent;
    [SerializeField] EquipmentSlots[] slots;

    public event Action<Item> ItemClickedEvent;

    private void Awake()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].LeftClickEvent += ItemClickedEvent;
        }
    }

    private void OnValidate()
    {
        slots = parent.GetComponentsInChildren<EquipmentSlots>();
    }

    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].type == item.type)
            {
                previousItem = (EquippableItem) slots[i].Item;
                slots[i].Item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item == item)
            {
                slots[i].Item = null;
                return true;
            }
        }
        return false;
    }
}
