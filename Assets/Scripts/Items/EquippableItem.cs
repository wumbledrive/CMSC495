using UnityEngine;

//An enumerator for each equipment type (Subject to change)
public enum Equipment
{
    Helmet,
    Chestpiece,
    Pants,
    Weapon,
    Sheild,
    Accessory
}

//CreateAssetMenu makes something createable in the Unity Asset Menu (Like creating a folder)
[CreateAssetMenu(menuName = "Items/Equippable Item")]
public class EquippableItem : Item
{
    //Some stats for the equipment (Subject to change)
    public int Strength;
    public int Defense;
    public int Magic;
    public int Intelligence;

    //Defining the equipment type
    public Equipment type;

    public void Equip(Player p)
    {
        p.Strength.AddMod(new StatModifiers(Strength, this));
        p.Defense.AddMod(new StatModifiers(Defense, this));
        p.Magic.AddMod(new StatModifiers(Magic, this));
        p.Intelligence.AddMod(new StatModifiers(Intelligence, this));
    }

    public void Unequip(Player p)
    {
        p.Strength.RemoveAllMods(this);
        p.Defense.RemoveAllMods(this);
        p.Magic.RemoveAllMods(this);
        p.Intelligence.RemoveAllMods(this);
    }

    public override Item GetCopy()
    {
        return Instantiate(this);
    }

    public override void Destroy()
    {
        Destroy(this);
    }
}
