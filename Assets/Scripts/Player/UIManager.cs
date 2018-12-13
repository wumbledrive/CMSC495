using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    // A reference to all the action buttons
    [SerializeField]
    private Button[] actionButtons;

    // Keycodes used for executing the action buttons
    private KeyCode action1, action2, action3, action4;

	// Use this for initialization
	void Start () 
    {
        //Keybinds
        action1 = KeyCode.Alpha1;
        action2 = KeyCode.Alpha2;
        action3 = KeyCode.Alpha3;
        action4 = KeyCode.Alpha4;

    }
	
	// Update is called once per frame
	void Update () 
    {
		if (Input.GetKeyDown(action1))
        {
            ActionButtonOnClick(0);
        }

        if (Input.GetKeyDown(action2))
        {
            ActionButtonOnClick(1);
        }

        if (Input.GetKeyDown(action3))
        {
            ActionButtonOnClick(2);
        }

        if (Input.GetKeyDown(action4))
        {
            ActionButtonOnClick(3);
        }
    }

    // Executes an action based on the button clicked
    private void ActionButtonOnClick(int btnIndex)
    {
        actionButtons[btnIndex].onClick.Invoke();
    }
}
