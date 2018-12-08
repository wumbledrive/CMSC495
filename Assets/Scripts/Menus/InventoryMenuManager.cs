using UnityEngine;
using CharacterStatsSpace;

public class InventoryMenuManager : MonoBehaviour {

    [SerializeField] Inventory inven;
    [SerializeField] EquipmentPanel ePanel;
    [SerializeField] StatsPanel sPanel;

    private void Awake()
    {
        sPanel.SetStats(Player.instance.Strength, Player.instance.Defense, 
            Player.instance.Magic, Player.instance.Intelligence);
        sPanel.UpdateValues();

        inven.ItemClickedEvent += HandleInv;
        ePanel.ItemClickedEvent += UnequipFromEquipPanel;
    }

    private void HandleInv(Item item)
    {
        if (item is EquippableItem)
        {
            Equip((EquippableItem) item);
        } else if (item is UsableItem)
        {
            UsableItem usable = (UsableItem)item;
            usable.Use(this);

            if (usable.consumable)
            {
                inven.RemoveItem(usable);
                usable.Destroy();
            }
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
                    previousItem.Unequip(Player.instance);
                    sPanel.UpdateValues();
                }
                item.Equip(Player.instance);
                sPanel.UpdateValues();
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
            item.Unequip(Player.instance);
            sPanel.UpdateValues();
            inven.AddItem(item);
        }
    }

    public void UseItem()
    {

    }
}
