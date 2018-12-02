using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Potion")]
public class HealthPotion : Item, IUseable
{
    [SerializeField]
    private int health;

    public void Use()
    {
        if (Player.MyInstance.health.MyCurrentValue < Player.MyInstance.health.MyMaxValue)
            Player.MyInstance.health.MyCurrentValue += health;
    }
}