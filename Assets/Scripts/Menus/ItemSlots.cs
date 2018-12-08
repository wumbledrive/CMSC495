using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Each item is stored in a specfic spot in the inventory UI
public class ItemSlots : MonoBehaviour, IPointerClickHandler
{
    //The image for the slot itself
    [SerializeField]
    private Image image;
    [SerializeField]
    private Text amountText;

    public event Action<Item> LeftClickEvent;

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

    private int _amount;
    public int Amount
    {
        get { return _amount; }
        set
        {
            _amount = value;
            amountText.enabled = _item != null && _item.MaximumStack > 1 && _amount > 1;
            if (amountText.enabled)
                amountText.text = _amount.ToString();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (Item != null && LeftClickEvent != null)
                LeftClickEvent(Item);
        }
    }

    //OnValidate is called when script is loaded or value is changed
    protected virtual void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();

        if (amountText == null)
            amountText = GetComponentInChildren<Text>();
    }
}
