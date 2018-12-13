using System;
using UnityEngine;

[Serializable]//A class for paring up blocks
public class Block
{
    //A pair of blocks
    [SerializeField]
    private GameObject first, second;

    // Deactivates the pair
    public void Deactivate()
    {
        first.SetActive(false);
        second.SetActive(false);
    }


    // Activates the pair
    public void Activate()
    {
        first.SetActive(true);
        second.SetActive(true);
    }
}