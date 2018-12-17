using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                //assigns the colliding object to hit variable
                var hit = collision.gameObject;
                //calls this script so the damage gets sent to the right place
                var health = hit.GetComponent<EnemyCharacterStats>();
                //sends 10 physical damage to colliding unit
                health.SendMessage("PhysicalDamage", 15);
            }
        }
    }
