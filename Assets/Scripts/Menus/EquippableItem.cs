using UnityEngine;

//An enumerator for each equipment type (Subject to change)
public enum Equipment
{
    Helmet,
    Chestpiece,
    Pants,
    Weapon,
    Sheild,
    Accessory,
}

//CreateAssetMenu makes something createable in the Unity Asset Menu (Like creating a folder)
[CreateAssetMenu]
public class EquippableItem : Item
{
    //Some stats for the equipment (Subject to change)
    public int Intelligence;
    public int Strength;
    public int Dexterity;
    public int Magic;
    public int Defense;

    //Defining the equipment type
    public Equipment type;

}
