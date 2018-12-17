using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{

    // A reference to the spell's rigid body
    private Rigidbody2D myRigidBody;
    private float damageDealt;

    // The spell's movement speed
    [SerializeField]
    private float speed;

    // The spells target
    public Transform MyTarget { get; private set; }

    private Transform source;

    private int damage;

    // Use this for initialization
    void Start()
    {
        //Creates a reference to the spell's rigidbody
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Transform target, int damage, Transform source)
    {
        this.MyTarget = target;
        this.damage = damage;
        this.source = source;
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

            Character c = collision.GetComponentInParent<Character>();
            speed = 0;
            c.TakeDamage(damage, source);
            GetComponent<Animator>().SetTrigger("impact");
            myRigidBody.velocity = Vector2.zero;
            MyTarget = null;

            //Previous lines
            //calls this script so the damage gets sent to the right place
            //var health = MyTarget.GetComponent<EnemyCharacterStats>();
            ////sends magic damage to colliding unit
            ////health.SendMessage("MagicalDamage", damageDealt);
            //GetComponent<Animator>().SetTrigger("impact");
            //myRigidBody.velocity = Vector2.zero;
            //MyTarget = null;
        }
    }

    //SAMS EDIT: adding magic modifier to spell script
    //private void MagicInput(float dmgMod)
    //{
    //    damageDealt = dmgMod;
    //}
}
