using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Each item is stored in a specfic spot in the inventory UI
public class ItemSlots : MonoBehaviour
{
    //The image for the slot itself
    [SerializeField]
    private Image image;

    //Gets the item in the slot and sets the item
    private Item _item;
    public Item Item
    {
        get
        {
            return _item;
        }
        set
        {
            _item = value;
            if (_item == null)
                image.enabled = false;
            else
            {
                image.sprite = _item.Icon;
                image.enabled = true;
            }
        }
    }

    //OnValidate is called when script is loaded or value is changed
    private void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();
    }
}
