using UnityEngine;

//An enumerator for each equipment type (Subject to change)
public enum equipment
{
    Helmet,
    Chestpiece,
    Gloves,
    Weapon,
    Shield,
    Accessory
}

//CreateAssetMenu makes something createable in the Unity Asset Menu (Like creating a folder)
[CreateAssetMenu]
public class EquippableItem : Item
{
    //Some stats for the equipment (Subject to change)
    public int strength;
    public int speed;
    public int defense;

    //Defining the equipment type
    public equipment piece;

}
