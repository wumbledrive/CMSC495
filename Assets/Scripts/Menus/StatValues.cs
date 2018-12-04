using UnityEngine;
using UnityEngine.UI;

public class StatValues : MonoBehaviour {

    public Text Value;

    private void OnValidate()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        Value = texts[0];
    }

}
