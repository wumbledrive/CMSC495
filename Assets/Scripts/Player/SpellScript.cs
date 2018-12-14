using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{

    // A reference to the spell's rigid body
    private Rigidbody2D myRigidBody;

    // The spell's movement speed
    [SerializeField]
    private float speed;

    // The spells target
    public Transform MyTarget { get; set; }

    // Use this for initialization
    void Start()
    {
        //Creates a reference to the spell's rigidbody
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (MyTarget != null)
        {
            //Calculates the spells direction
            Vector2 direction = MyTarget.position - transform.position;

            //Moves the spell by using the rigid body
            myRigidBody.velocity = direction.normalized * speed;

            //Calculates the rotation angle
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //Rotates the spell towards the target
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hitbox" && collision.transform == MyTarget)
        {
            GetComponent<Animator>().SetTrigger("impact");
            myRigidBody.velocity = Vector2.zero;
            MyTarget = null;
        }
    }
}
