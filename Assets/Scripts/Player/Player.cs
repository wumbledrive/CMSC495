using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterStatsSpace;

public class Player : Character {

    public static Player instance = null;

    public CharacterStats Level;
    public CharacterStats Strength;
    public CharacterStats Defense;
    public CharacterStats Magic;
    public CharacterStats Intelligence;

    public Status health;

    [SerializeField]
    private Status mana;

    [SerializeField]
    private PauseMenu pause;

    [SerializeField]
    private Status exp;

    private float startingExp = 1;
    private float maxExp = 100;
    private float maxMana = 100;
    private float maxHealth = 100;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    protected override void Start() {

        //Initializes health and mana values
        health.Initialize(maxHealth, maxHealth);
        mana.Initialize(maxMana, maxMana);
        exp.Initialize(startingExp, maxExp);

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
        if (Input.GetKeyDown(KeyCode.N))
            exp.MyCurrentValue -= 10;
        if (Input.GetKeyDown(KeyCode.M))
            exp.MyCurrentValue += 10;
        if (Input.GetKeyDown(KeyCode.J))
            LevelUp();

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
        //Spacebar for attack
        if (Input.GetKeyDown(KeyCode.Space))
            attackRoutine = StartCoroutine(Attack());
    }

    public void LevelUp()
    {
        Level.BaseValue++;
        int ran = Random.Range(1, 5);
        Strength.BaseValue += ran;
        ran = Random.Range(1, 5);
        Defense.BaseValue += ran;
        ran = Random.Range(1, 5);
        Magic.BaseValue += ran;
        ran = Random.Range(1, 5);
        Intelligence.BaseValue += ran;
    }

    public void TakeDamage(float damage)
    {
        health.MyCurrentValue -= damage;
    }

    //Attack timing and stopattack check
    private IEnumerator Attack()
    {
        if (!isAttacking && !(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1))
        {
            isAttacking = true;

            myAnim.SetBool("attack", isAttacking);

            yield return new WaitForSeconds(0.8F); //cast time on spacebar press

            StopAttack();
        }

    }
}
