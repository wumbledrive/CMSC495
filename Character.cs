using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abstract class for a character (Player, Enemy, NPC, etc.)
public abstract class Character : MonoBehaviour {

    //Speed and Direction for movement
    [SerializeField]
    private float speed;

    private Rigidbody2D body;

    protected Vector2 direction;

    // Use this for initialization
    protected virtual void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
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
}
