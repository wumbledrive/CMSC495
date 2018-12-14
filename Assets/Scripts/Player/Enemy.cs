using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC 
{
    // A canvasgroup for the healthbar
    [SerializeField]
    private CanvasGroup healthGroup;

    // When the enemy is selected
    public override Transform Select()
    {
        healthGroup.alpha = 1;
        return base.Select();
    }

    // When we deselect our enemy
    public override void DeSelect()
    {
        healthGroup.alpha = 0;
        base.DeSelect();
    }

}
