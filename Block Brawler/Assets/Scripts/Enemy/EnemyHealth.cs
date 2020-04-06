using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Punch
{
    //Amount of health the enemy has
    [SerializeField] private float health = 10f;

    //Determines if the enemy is dead
    protected static bool isDead = false;

    //Time used to freeze the enemy
    private float waitTime = 1f;

    //Checks for collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        /* If the player hits the enemy with his fist,
         * The enemy will take damage, according to how much damage the fist does
         */
        if(collision.collider.tag == "Fist")
        {
            health -= punchDamage;
        }    
    }

    void Update()
    {
        //If the enemy runs out of health, they die
        if (health <= 0f)
        {
            Death();
        }
    }

    //Activated when the enemy dies
    void Death()
    {
        /* If the enemy dies, isDead is set to true,
         * The enemy falls over dead, and the enemy stops moving
         */
        isDead = true;
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5f, ForceMode2D.Force);
        waitTime -= Time.deltaTime;

        if(waitTime <= 0f)
        {
            waitTime = 0f;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
