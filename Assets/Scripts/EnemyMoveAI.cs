using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAI : MonoBehaviour
{
    public float speed, stopDistance, chaseRange, damage, lastAttackTime, attackRate;
    public int attackDelay;
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        //chaseRange detirmines if player is close enough to draw agro
        if (Vector2.Distance(transform.position, target.position) < chaseRange)
        {

            if (Vector2.Distance(transform.position, target.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else //if within stop distance causes short windup then attack
            {
                //ensures enemies dont attack every frame
                if (Time.time > (lastAttackTime + attackRate))
                {
                    System.Threading.Thread.Sleep(attackDelay); //set in milliseconds (1/1000th second)
                    Attack();
                }
            }
        }

     }

    void Attack()
    {
        //creature lunges 1 space forward if they collide with the player it sends a damage message to the player
        transform.position = Vector2.MoveTowards(transform.position, target.position, 1);
    }

    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.transform.tag == "Player")
        {
            //Sends damage message to player
            target.SendMessage("TakeDamage", damage);
            lastAttackTime = Time.time;
            System.Threading.Thread.Sleep(1000);
        }
    }
}
