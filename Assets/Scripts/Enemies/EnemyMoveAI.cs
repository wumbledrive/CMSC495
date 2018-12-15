using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAI : MonoBehaviour
{
    public float speed, stopDistance, chaseRange, damage, lastAttackTime, attackRate;
    public int attackDelay;
    private Transform target;
    //public Collider2D attackTrigger;
    public bool attacking=false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //attackTrigger.enabled = false;
    }


    void Update()
    {
        //chaseRange detirmines if player is close enough to draw agro
        if (Vector2.Distance(transform.position, target.position) < chaseRange)
        {
            if (Time.time > (lastAttackTime + attackRate))
            {
                if (Vector2.Distance(transform.position, target.position) > stopDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
                else //if within stop distance causes short windup then attack
                {
                    //ensures enemies dont attack every frame

                    attacking = true;
                    //System.Threading.Thread.Sleep(attackDelay); //set in milliseconds (1/1000th second)
                    Attack();
                    // attackTrigger.enabled = true; 
                    attacking = false;

                }
            }
        }

     }

    void Attack()
    {
        //creature lunges forward, if they collide with the player it sends a damage message to the player

        transform.position = Vector2.MoveTowards(transform.position, target.position, 1);
    }

    void OnCollisionEnter2D(Collision2D hitObject)
    {
        if (hitObject.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collide");
            //Sends damage message to player
            target.SendMessage("PhysicalDamage", damage);
            lastAttackTime = Time.time;
            transform.position = Vector2.MoveTowards(transform.position, target.position, -1);
            transform.position = Vector2.MoveTowards(transform.position, target.position, 1*Time.deltaTime);
        }
    }
}
