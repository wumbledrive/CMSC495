using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/UsableItem")]
public class UsableItem : Item {

    public bool consumable;

    public List<UsableItemEffects> Effects;

    public virtual void Use(InventoryMenuManager imm)
    {
        foreach (UsableItemEffects effect in Effects)
        {
            effect.ExecuteEffect(this, Player.instance);
        }
    }

}
