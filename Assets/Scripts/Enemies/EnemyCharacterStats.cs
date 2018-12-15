using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterStats : MonoBehaviour {
    private float currentHP;
    public float maxHealth;
    public float strength;
    public float defense;

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
   //sends 10 damage to colliding unit
        health.SendMessage("TakeDamage", 10);
    }
         
      END EXAMPLE*/

    //to make enemy take damage identify the enemy target and send damage as [enemy object].SendMessage("TakeDamage", damage);
    public void TakeDamage(string type)
    {
        if (type.Equals("physical"))
        {
            float damage = 0;
            //Use the player strength and enemy's defense to calculate damage
            currentHP -= damage;
        }

        if (type.Equals("magical"))
        {
            float damage = 0;
            //Use the player magic and enemy's intelligence to calculate damage
            currentHP -= damage;
        }
        //Enemies who drop below 0 are removed from the game
        //Add death animation if we have one
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
