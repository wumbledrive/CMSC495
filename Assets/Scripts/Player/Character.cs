using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an abstract class that all characters needs to inherit from
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour
{


    /// <summary>
    /// The Player's movement speed
    /// </summary>
    [SerializeField]
    private float speed;

    /// <summary>
    /// A reference to the character's animator
    /// </summary>
    public Animator myAnim { get; set; }

    /// <summary>
    /// The Player's direction
    /// </summary>
    public Vector2 direction;

    /// <summary>
    /// The Character's rigidbody
    /// </summary>
    private Rigidbody2D body;

    /// <summary>
    /// indicates if the character is attacking or not
    /// </summary>
    public bool isAttacking { get; set; }

    /// <summary>
    /// A reference to the attack coroutine
    /// </summary>
    protected Coroutine attackRoutine;

    [SerializeField]
    protected Transform hitBox;

    [SerializeField]
    public Status health;

    public Transform MyTarget { get; set; }

    public Status MyHealth
    {
        get { return health; }
    }

    /// <summary>
    /// The character's initialHealth
    /// </summary>
    [SerializeField]
    private float initHealth;

    /// <summary>
    /// Indicates if character is moving or not
    /// </summary>
    public bool IsMoving
    {
        get
        {
            return Direction.x != 0 || Direction.y != 0;
        }
    }

    public Vector2 Direction
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public bool IsAlive
    {
        get
        {
            return health.MyCurrentValue > 0;
        }
    }

    protected virtual void Start()
    {
        health.Initialize(initHealth, initHealth);

        //Makes a reference to the rigidbody2D
        body = GetComponent<Rigidbody2D>();

        //Makes a reference to the character's animator
        myAnim = GetComponent<Animator>();
    }

    /// <summary>
    /// Update is marked as virtual, so that we can override it in the subclasses
    /// </summary>
    protected virtual void Update()
    {
        HandleLayers();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Moves the player
    /// </summary>
    public void Move()
    {
        if (IsAlive)
        {
            //Makes sure that the player moves
            body.velocity = Direction.normalized * Speed;
        }

    }

    /// <summary>
    /// Makes sure that the right animation layer is playing
    /// </summary>
    public void HandleLayers()
    {
        if (IsAlive)
        {
            //Checks if we are moving or standing still, if we are moving then we need to play the move animation
            if (IsMoving)
            {
                ActivateLayer("WalkLayer");

                //Sets the animation parameter so that he faces the correct direction
                myAnim.SetFloat("x", Direction.x);
                myAnim.SetFloat("y", Direction.y);
            }
            else if (isAttacking)
            {
                ActivateLayer("AttackLayer");
            }
            else
            {
                //Makes sure that we will go back to idle when we aren't pressing any keys.
                ActivateLayer("IdleLayer");
            }
        }
        else
        {
            ActivateLayer("DeathLayer");
        }

    }

    /// <summary>
    /// Activates an animation layer based on a string
    /// </summary>
    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < myAnim.layerCount; i++)
        {
            myAnim.SetLayerWeight(i, 0);
        }

        myAnim.SetLayerWeight(myAnim.GetLayerIndex(layerName), 1);
    }

    /// <summary>
    /// Makes the character take damage
    /// </summary>
    /// <param name="damage"></param>
    public virtual void TakeDamage(float damage, Transform source)
    {
        health.MyCurrentValue -= damage;

        if (health.MyCurrentValue <= 0)
        {
            //Makes sure that the character stops moving when its dead
            direction = Vector2.zero;
            body.velocity = direction;
            myAnim.SetTrigger("die");
        }
    }

}

