using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

//Abstract class for a character (Player, Enemy, NPC, etc.)
public abstract class Character : MonoBehaviour
{

    //Speed and Direction for movement
    [SerializeField]
    private float speed;

    //A reference to Rigidbody2D
    private Rigidbody2D body;

    //boolean for yes/no attacking
    protected bool isAttacking = false;

    // The Player's direction
    protected Vector2 direction;

    //Coroutine variable to track animation timing attack issues
    protected Coroutine attackRoutine;

    // A reference to the character's animator
    protected Animator myAnim;

    //hitbox
    [SerializeField]
    protected Transform hitBox;

    //health
    //[SerializeField]
    //private Status health;

    // Use this for initialization

    protected virtual void Start()
    {
        //Makes a reference to the rigidbody2D
        body = GetComponent<Rigidbody2D>();

        //Makes a reference to the character's animator
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        HandleLayers();
    }

    private void FixedUpdate()
    {
        //Calls the Move function
        Move();
    }

    public void Move()
    {
        //Moves character based on speed and direction
        body.velocity = direction.normalized * speed;


    }

    public void HandleLayers()
    {
        body.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;

        myAnim.SetFloat("moveX", body.velocity.x);
        myAnim.SetFloat("moveY", body.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {

            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));

            StopAttack();
        }

        if (isAttacking)
        {
            ActivateLayer("AttackLayer");
        }

    }

    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < myAnim.layerCount; i++)
        {
            myAnim.SetLayerWeight(i, 0);
        }

        myAnim.SetLayerWeight(myAnim.GetLayerIndex(layerName), 1);
    }

    //Stop attack on movement
    public virtual void StopAttack()
    {
        isAttacking = false; //Makes sure that we are not attacking

        myAnim.SetBool("attack", isAttacking); //Stops the attack animation

        if (attackRoutine != null) //Checks if we have a reference to an co routine
        {
            StopCoroutine(attackRoutine);
        }



    }
}

