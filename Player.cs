using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    [SerializeField]
    private Status health;

    [SerializeField]
    private Status mana;

    private float maxMana = 100;
    private float maxHealth = 100;

	// Use this for initialization
	protected override void Start () {

        //Initializes health and mana values
        health.Initialize(maxHealth, maxHealth);
        mana.Initialize(maxMana, maxMana);

        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
        //Calls the GetInput function then the Move function from character
        GetInput();
        base.Update();
	}

    //Gets the current direction based on user input
    private void GetInput()
    {
        //Used for debugging Health and Mana values
        if(Input.GetKeyDown(KeyCode.I))
            health.MyCurrentValue -= 10;
        if (Input.GetKeyDown(KeyCode.O))
            health.MyCurrentValue += 10;
        if (Input.GetKeyDown(KeyCode.K))
            mana.MyCurrentValue -= 15;
        if (Input.GetKeyDown(KeyCode.L))
            mana.MyCurrentValue += 15;

        //Zeroes out direction
        direction = Vector2.zero;

        //Finds new direction
        if(Input.GetKey(KeyCode.W))
            direction += Vector2.up;
        if (Input.GetKey(KeyCode.A))
            direction += Vector2.left;
        if (Input.GetKey(KeyCode.S))
            direction += Vector2.down;
        if (Input.GetKey(KeyCode.D))
            direction += Vector2.right;
    }
}
