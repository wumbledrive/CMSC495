using UnityEngine;

[CreateAssetMenu(menuName = "Items/Effects/Healing")]
public class HealEffect : UsableItemEffects {

    public int HealingAmount;

    public override void ExecuteEffect(UsableItem parent, Player player)
    {
        player.health.MyCurrentValue += HealingAmount;
    }
}
