using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour {

    [SerializeField] Text ItemName;
    [SerializeField] Text ItemSlot;
    [SerializeField] Text ItemStats;

    private StringBuilder builder = new StringBuilder();

    private void Awake()
    {
        HideTooltip();
    }

    public void ShowTooltip(EquippableItem item)
    {
        ItemName.text = item.ItemName;
        ItemSlot.text = item.type.ToString();

        builder.Length = 0;
        AddStat(item.Strength, "Strength");
        AddStat(item.Defense, "Defense");
        AddStat(item.Magic, "Magic");
        AddStat(item.Intelligence, "Intelligence");

        ItemStats.text = builder.ToString();

        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    private void AddStat(float value, string name)
    {
        if (value != 0)
        {
            if (builder.Length > 0)
                builder.AppendLine();

            if (value > 0)
                builder.Append("+");
            builder.Append(value);
            builder.Append(" ");
            builder.Append(name);
        }
    }

}
