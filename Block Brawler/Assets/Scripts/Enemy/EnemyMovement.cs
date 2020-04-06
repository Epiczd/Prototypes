using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyHealth
{
    //Speed the enemy moves
    [SerializeField] private float moveSpeed = 10f;

    //The area the enemy can move in
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;

    //Direction the enemy is moving
    private Vector2 movingDirection = Vector2.left;

    // Update is called once per frame
    void Update()
    {
        //As long as the enemy is alive, it will move
        if(isDead == false)
        {
            Movement();
        }
    }

    //Allows the enemy to move
    void Movement()
    {
        /* If the enemy's x position is greater than or equal to xMin,
         * and less than xMax, the enemy will move right,
         * If the enemy's x position is less than or equal to xMax,
         * and greater than xMin, the enemy will move left.
         */

        if (transform.position.x > xMax)
        {
            movingDirection = Vector2.left;
        }
        else if (transform.position.x < xMin)
        {
            movingDirection = Vector2.right;
        }

        //Controls the enemy's movement
        transform.Translate(movingDirection * Time.deltaTime * moveSpeed);
    }
}
