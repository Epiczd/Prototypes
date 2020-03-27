using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //How the enemy can see
    [SerializeField] private Camera enemyVision;

    //Speed the enemy moves
    [SerializeField] private float enemySpeed;

    //The distance the enemy can see
    [SerializeField] private float lineOfSight = 10f;

    //The target (player) for the enemy to movetowards
    [SerializeField] private Transform target;

    //Checks if the player has been detected by the enemy
    private bool playerDetected = false;

    /* Checks for the player, if the player is detected,
     * the enemy will start to move towards the player
     */
    void Update()
    {
        CheckForPlayer();

        if (playerDetected)
        {
            UpdateMovement();
        }
    }

    //If the enemy is detected by the player, playerDetected is set to true
    void CheckForPlayer()
    {
        RaycastHit hit;

        if(Physics.Raycast(enemyVision.transform.position, enemyVision.transform.forward, out hit, lineOfSight))
        {
            if(hit.collider.tag == "Player")
            {
                playerDetected = true;
            }
        }
    }

    //When the player is detected, the enemy will start following it
    void UpdateMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
    }
}
