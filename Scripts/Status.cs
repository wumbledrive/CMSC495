using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour {

    private Image content;

    [SerializeField]
    private float lerpSpeed;

    private float currentFill;

    public float MyMaxValue { get; set; }

    private float currentValue;

    //Property to find the current value for a status and the fill amount
    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            //Health and mana cannot go above the max
            if (value > MyMaxValue)
                currentValue = MyMaxValue;
            //Health and mana cannot go below 0
            else if (value < 0)
                currentValue = 0;
            //Sets the current health and mana value
            else
                currentValue = value;

            currentFill = currentValue / MyMaxValue;
        }
    }

	// Use this for initialization
	void Start() {
        content = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update() {
        //Updates the health or mana bar each frame
        if (currentFill != content.fillAmount)
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
    }

    //Initializes current status using given amounts
    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}
