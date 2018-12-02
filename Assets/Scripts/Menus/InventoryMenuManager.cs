using UnityEngine;

public class InventoryMenuManager : MonoBehaviour {

    [SerializeField] Inventory inven;
    [SerializeField] EquipmentPanel ePanel;

    private void Awake()
    {
        inven.ItemClickedEvent += HandleInv;
        ePanel.ItemClickedEvent += UnequipFromEquipPanel;
    }

    private void HandleInv(Item item)
    {
        if (item is EquippableItem)
        {
            Equip((EquippableItem) item);
        } else if (item is IUseable)
        {
            (item as IUseable).Use();
            inven.RemoveItem(item);
        }
    }

    private void UnequipFromEquipPanel(Item item)
    {
        if (item is EquippableItem)
        {
            Unequip((EquippableItem) item);
        }
    }

    public void Equip(EquippableItem item)
    {
        if (inven.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (ePanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inven.AddItem(previousItem);
                }
            }
            else
            {
                inven.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if (!inven.IsFull() && ePanel.RemoveItem(item))
        {
            inven.AddItem(item);
        }
    }

    public void UseItem()
    {

    }
}
