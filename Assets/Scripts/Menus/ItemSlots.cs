using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Each item is stored in a specfic spot in the inventory UI
public class ItemSlots : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //The image for the slot itself
    [SerializeField]
    private Image image;
    [SerializeField]
    private Text amountText;

    [SerializeField] ItemTooltip tooltip;

    public event Action<Item> LeftClickEvent;

    private Color dis = new Color(0, 0, 0, 0);
    private Color ena = Color.white;

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
                image.color  = dis;
            else
            {
                image.sprite = _item.Icon;
                image.color = ena;
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

        if (tooltip == null)
            tooltip = FindObjectOfType<ItemTooltip>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Item is EquippableItem) 
            tooltip.ShowTooltip((EquippableItem) Item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }
}
