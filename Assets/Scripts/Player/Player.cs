using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterStatsSpace;


//functionality that is specific to the Player
public class Player : Character
{

    public static Player instance = null;

    public CharacterStats Level;
    public CharacterStats Strength;
    public CharacterStats Defense;
    public CharacterStats Magic;
    public CharacterStats Intelligence;

    public int KillCount = 0;

    // The player's mana
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

    //initial mana
    private float initMana = 50;

    //Blocking so player can't shoot spells behind
    [SerializeField]
    private Block[] blocks;

    // Exit points for the spells and sword attack
    [SerializeField]
    private Transform[] exitPoints;

    //Index that keeps track of which exit point to use, 2 is default down
    private int exitIndex = 2;

    private SpellBook spellBook;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

    }

    protected override void Start()
    {
        spellBook = GetComponent<SpellBook>();

        mana.Initialize(initMana, initMana);

        //Initializes health and mana values
        //health.Initialize(maxHealth, maxHealth);
        //mana.Initialize(maxMana, maxMana);
        //mana.Initialize(initMana, initMana);
        exp.Initialize(startingExp, maxExp);

        pause.pauseUI.SetActive(false);
        pause.invUI.SetActive(false);
        pause.gameOverUI.SetActive(false);

        base.Start();
    }


    //Update is called once per frame
    protected override void Update()
    {
        //Calls the GetInput function then the Move function from character
        GetInput();

        base.Update();

        if (health.MyCurrentValue == 0)
        {
            PauseMenu.gameOver = true;
            health.MyCurrentValue = maxHealth;
            mana.MyCurrentValue = maxMana;
        }

        if (KillCount >= 4)
        {
            SceneLoader loader = new SceneLoader();
            loader.loadWinScreen();
        }
    }

    /// <summary>
    /// Listen's to the players input
    /// </summary>
    private void GetInput()
    {
        direction = Vector2.zero;

        //Used for debugging Health and Mana values
        if (Input.GetKeyDown(KeyCode.I))
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

        if (Input.GetKey(KeyCode.W)) //Moves up
        {
            exitIndex = 0;
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A)) //Moves left
        {
            exitIndex = 3;
            direction += Vector2.left; //Moves down
        }
        if (Input.GetKey(KeyCode.S))
        {
            exitIndex = 2;
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D)) //Moves right
        {
            exitIndex = 1;
            direction += Vector2.right;
        }
        if (IsMoving)
        {
            StopAttack();
        }


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

    //takes physical damage
    //public void PhysicalDamage(float incDmg)
    //{
    //float damage = incDmg - Defense.FinalValue();
    //Use the enemy's strength and player defense to calculate damage to the player
    //health.MyCurrentValue -= damage;
    //}

    //takes magic damage
    //public void MagicalDamage(float incDmg)
    //{
    //float damage = incDmg - Intelligence.FinalValue();
    //Use the enemy's strength and player defense to calculate damage to the player 
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

            s.Initialize(currentTarget, newSpell.MyDamage, transform);
            //SAMS EDIT: added Magic level adjustment
            //s.SendMessage("MagicInput", Magic.FinalValue());
        }

        StopAttack(); //Ends the attack
    }

    // Casts a spell
    public void CastSpell(int spellIndex)
    {
        Block();

        if (MyTarget != null && MyTarget.GetComponentInParent<Character>().IsAlive && !isAttacking && !IsMoving && InLineOfSight()) //Chcks if we are able to attack
        {
            attackRoutine = StartCoroutine(Attack(spellIndex));
        }
    }

    /// <summary>
    /// Checks if the target is in line of sight
    /// </summary>
    /// <returns></returns>
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

    // Changes the blocks based on the players direction
    private void Block()
    {
        foreach (Block b in blocks)
        {
            b.Deactivate();
        }

        blocks[exitIndex].Activate();
    }

    // Stops the attack
    public void StopAttack()
    {
        //Stop the spellbook from casting
        spellBook.StopCating();

        isAttacking = false; //Makes sure that we are not attacking

        myAnim.SetBool("attack", isAttacking); //Stops the attack animation

        if (attackRoutine != null) //Checks if we have a reference to an co routine
        {
            StopCoroutine(attackRoutine);
        }
    }
}