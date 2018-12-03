﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    
    public Status health;

    [SerializeField]
    private Status mana;

    [SerializeField]
    private PauseMenu pause;

    public CharacterStats Intelligence;
    public CharacterStats Strength;
    public CharacterStats Defense;
    public CharacterStats Magic;

    private float maxMana = 100;
    private float maxHealth = 100;
    internal static readonly Player MyInstance;

    // Use this for initialization
    protected override void Start() {

        //Initializes health and mana values
        health.Initialize(maxHealth, maxHealth);
        mana.Initialize(maxMana, maxMana);

        pause.pauseUI.SetActive(false);
        pause.invUI.SetActive(false);
        pause.gameOverUI.SetActive(false);

        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update() {
        //Calls the GetInput function then the Move function from character
        GetInput();
        base.Update();

        if (health.MyCurrentValue == 0)
        {
            PauseMenu.gameOver = true;
            health.MyCurrentValue = maxHealth;
            mana.MyCurrentValue = maxMana;
        }
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

        /*SAM COMMENTED OUT: I think this is what was causing pause not to work on escape lol
         if (Input.GetKeyDown(KeyCode.Escape))
            pause.PauseGame();*/

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

    public void TakeDamage(float damage)
    {
        health.MyCurrentValue -= damage;
    }
}