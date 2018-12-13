using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    // The player's health
    public Status health;

    // The player's mana
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

    //[SerializeField] //spellPrefab array
    //private GameObject[] spellPrefab;

    [SerializeField]
    private Block[] blocks;

    [SerializeField]
    private Transform[] exitPoints;

    private int exitIndex = 2;

    private SpellBook spellBook;

    //Choosing targets
    public Transform MyTarget { get; set; }

    // Use this for initialization
    protected override void Start() {

        //Initializes SpellBook
        spellBook = GetComponent<SpellBook>();
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
        if (Input.GetKey(KeyCode.W)) 
            {
                exitIndex = 0;
                direction += Vector2.up;
            }

        if (Input.GetKey(KeyCode.A))
            {
                exitIndex = 3;
                direction += Vector2.left;
            }

        if (Input.GetKey(KeyCode.S))
            {
                exitIndex = 2;
                direction += Vector2.down;
            }

        if (Input.GetKey(KeyCode.D))
            {
                exitIndex = 1;
                direction += Vector2.right;
            }

        //Spacebar for sword attack re-adding later
        //if (Input.GetKeyDown(KeyCode.Space)){}

    }

    //public void TakeDamage(float damage)
    //{
    //health.MyCurrentValue -= damage;
    //}

    //Attack timing and stopattack check
    private IEnumerator Attack(int spellIndex)
    {
        Transform currentTarget = MyTarget;

        //Creates a new spell, so that we can use the information form it to cast it in the game
        Spell newSpell = spellBook.CastSpell(spellIndex);

        isAttacking = true; //Indicates if we are attacking

        myAnim.SetBool("attack", isAttacking); //Starts the attack animation

        yield return new WaitForSeconds(newSpell.MyCastTime); //This is a hardcoded cast time, for debugging

        if (currentTarget != null && InLineOfSight())
        {
            SpellScript s = Instantiate(newSpell.MySpellPrefab, exitPoints[exitIndex].position, Quaternion.identity).GetComponent<SpellScript>();
            s.MyTarget = currentTarget;
        }

        StopAttack(); //Ends the attack
    }

    // Casts a spell
    public void CastSpell(int spellIndex)
    {
        Block();

        if (MyTarget != null && !isAttacking && InLineOfSight() && !(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1))
        {
            attackRoutine = StartCoroutine(Attack(spellIndex));
        }
        
    }

    // Checks if the target is in line of sight
    private bool InLineOfSight() 
    {
        if (MyTarget != null)
        {
            //Calculates the target's direction
            Vector3 targetDirection = (MyTarget.transform.position - transform.position).normalized;

            //Thorws a raycast in the direction of the target
            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, Vector2.Distance(transform.position, MyTarget.transform.position), 256);

            //If we didn't hit the block, then we can cast a spell
            if (hit.collider == null)
            {
                return true;
            }
        }

        //If we hit the block we can't cast a spell
        return false; 
    }

    private void Block() 
    {
        foreach (Block b in blocks)
        {
            b.Deactivate();
        }

        blocks[exitIndex].Activate();
    }

    // Makes the player stop attacking
    public override void StopAttack()
    {
        //Stop the spellbook from casting
        spellBook.StopCating();

        //Makes sure that we stop the cast in our character.
        base.StopAttack();
    }
}
