using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CreateAssetMenu makes something createable in the Unity Asset Menu (Like creating a folder)
[CreateAssetMenu]
public class Item : ScriptableObject
{
    //Each Item is a scriptable object with a name and image
    public string ItemName;
    public Sprite Icon;
}
