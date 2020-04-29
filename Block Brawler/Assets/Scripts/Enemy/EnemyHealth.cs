using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Punch
{
    //Amount of health the enemy has
    [SerializeField] private float health = 10f;

    //Checks if the enemy is a boss
    [SerializeField] private bool isBoss = false;

    //The bosses healthbar
    [SerializeField] private BossHealthBar healthBar;

    //Time used to freeze the enemy
    private float waitTime = 1f;

    //Enemies max health
    private float maxHealth;

    //On start, if the enemy is a boss, it sets the max health
    void Start()
    {
        maxHealth = health;

        if (isBoss)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }

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

        if (isBoss)
        {
            healthBar.SetHealth(health);
        }
        
    }

    //Activated when the enemy dies
    void Death()
    {
        /* If the enemy dies, The enemy falls over dead, and the enemy stops moving,
         * The enemy will also stop doing damage, and will just lay on the floor
         */
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<EnemyMovement>().enabled = false;
        gameObject.tag = "Untagged";
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5f, ForceMode2D.Force);
        waitTime -= Time.deltaTime;

        if(waitTime <= 0f)
        {
            waitTime = 0f;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        //If the enemy was a boss, boss mode is disabled
        if (isBoss)
        {
            Boss.bossDead = true;
        }
        
    }
}
