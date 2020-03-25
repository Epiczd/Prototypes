using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //Amount of damage dealt by the enemy
    [SerializeField] private float damage;

    //Time in between each attack
    private float timeBtwAttack = 0f;

    /* While the enemy is attacking the player, 
     * they will lose health, according to the amount of damage dealt by the enemy
     */
    void OnCollisionStay(Collision collision)
    {
        while(collision.collider.tag == "Player" && timeBtwAttack == 0f)
        {
            timeBtwAttack++;
            PlayerHealth player = collision.transform.GetComponent<PlayerHealth>();

            player.TakeDamage(damage);
            break;
        }

        if(timeBtwAttack <= 1f && timeBtwAttack > 0f)
        {
            timeBtwAttack -= Time.deltaTime * 2.5f;
        }
        else
        {
            timeBtwAttack = 0f;
        }
    }
}
