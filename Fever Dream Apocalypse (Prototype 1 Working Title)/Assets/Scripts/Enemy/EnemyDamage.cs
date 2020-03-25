using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage;

    private float timeBtwAttack = 0f;

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
