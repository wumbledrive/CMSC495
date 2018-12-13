using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Spell
{
    // The Spell's name
    [SerializeField]
    private string name;

    // The spell's damage
    [SerializeField]
    private int damage;

    // The spell's icon
    [SerializeField]
    private Sprite icon;

    // The spell's speed
    [SerializeField]
    private float speed;

    // The spell's cast time
    [SerializeField]
    private float castTime;

    // The spell's prefab
    [SerializeField]
    private GameObject spellPrefab;

    // The spell's color
    [SerializeField]
    private Color barColor;

    // Property for accessing the spell's name
    public string MyName
    {
        get
        {
            return name;
        }
    }

    // Property for reading the damage
    public int MyDamage
    {
        get
        {
            return damage;
        }

    }

    // Property for reading the icon
    public Sprite MyIcon
    {
        get
        {
            return icon;
        }
    }

    // Property for reading the speed
    public float MySpeed
    {
        get
        {
            return speed;
        }
    }

    // Property for reading the cast time
    public float MyCastTime
    {
        get
        {
            return castTime;
        }
    }

    // Property for reading the spell's prefab
    public GameObject MySpellPrefab
    {
        get
        {
            return spellPrefab;
        }
    }

    // Property for reading the color
    public Color MyBarColor
    {
        get
        {
            return barColor;
        }
    }

}