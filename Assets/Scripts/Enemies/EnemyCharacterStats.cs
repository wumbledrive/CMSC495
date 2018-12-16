using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCharacterStats : MonoBehaviour {
    private float currentHP;
    public float maxHealth;
    public float defense;
    public float intelligence;

    // Use this for initialization
    void Start () {
        currentHP=maxHealth;
    }

    /*EXAMPLE METHOD for applying collision damage to an enemy with this script:

    void OnCollisionEnter2D(Collision2D hitObject)
    {
    //assigns the colliding object to hit variable
        var hit = hitObject.gameObject;
   //calls this script so the damage gets sent to the right place
        var health = hit.GetComponent<EnemyCharacterStats>();
   //sends 10 physical damage to colliding unit
        health.SendMessage("PhysicalDamage", 10);
    }
         
      END EXAMPLE*/

    //to make enemy take damage identify the enemy target and send damage as [enemy object].SendMessage("TakeDamage", damage);
    public void PhysicalDamage(float incDmg)
    {
            float damage = incDmg-defense;
            //Use the player strength and enemy's defense to calculate damage
            if (damage > 0)
            {
                currentHP -= damage;
            }
        //Enemies who drop below 0 are removed from the game
        //Add death animation if we have one
        if (currentHP <= 0)
        {
            Player player = Player.instance;
            player.KillCount++;
            Destroy(gameObject);
        }
    }

    public void MagicalDamage(float incDmg)
    {
        float damage = incDmg - intelligence;
        //Use the player strength and enemy's defense to calculate damage
        if (damage > 0)
        {
            currentHP -= damage;
        }
        //Enemies who drop below 0 are removed from the game
        //Add death animation if we have one
        if (currentHP <= 0)
        {
            Player player = Player.instance;
            player.KillCount++;
            Destroy(gameObject);
        }
    }
}
