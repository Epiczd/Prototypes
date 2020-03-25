using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : WaveManager
{
    //Amount of health the enemy has
    [SerializeField] private float health;
    
    //When the enemy takes damage, this subtracts from its health
    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0f)
        {
            EnemyDeath();
        }
    }

    //When the enemy reaches zero health, it will die
    void EnemyDeath()
    {
        enemiesKilled++;
        Destroy(gameObject);
    }
}
