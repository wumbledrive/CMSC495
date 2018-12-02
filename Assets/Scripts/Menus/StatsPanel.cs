using UnityEngine;

public class StatsPanel : MonoBehaviour {

    [SerializeField] StatValues[] values;

    private CharacterStats[] stats;

    private void Onvalidate()
    {
        values = GetComponentsInChildren<StatValues>();
    }

    public void SetStats(params CharacterStats[] charStats)
    {
        stats = charStats;

        if (stats.Length > values.Length)
        {
            Debug.LogError("There are not enough stat values for the given stats");
            return;
        }

        for (int i = 0; i < values.Length; i++)
        {
            values[i].gameObject.SetActive(i < stats.Length);
        }
    }

    public void UpdateValues()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            values[i].Value.text = stats[i].Value.ToString();
        }
    }
}
