using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Speed the enemy moves
    [SerializeField] private float moveSpeed = 10f;

    //The area the enemy can move in
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;

    //Determines if the enemy is allowed to jump
    [SerializeField] private bool canJump;

    //Force the enemy jumps
    [SerializeField] private float jumpForce = 5f;

    private float jumpTime = 1f;

    //Direction the enemy is moving
    private Vector2 movingDirection = Vector2.left;

    // Update is called once per frame
    void Update()
    {
        //As long as the enemy is alive, it will move
        Movement();
    }

    //Allows the enemy to move
    void Movement()
    {
        if(canJump == false)
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
        else
        {
            /* If the enemy's y position is greater than or equal to yMin,
             * and less than yMax, the enemy will jump,
             * If the enemy's y position is less than or equal to yMax,
             * and greater than yMin, the enemy will fall down
             */
            if(transform.position.y > yMax)
            {
                movingDirection = Vector2.down;
            }
            else if(transform.position.y < yMin)
            {
                movingDirection = Vector2.up;
            }
            //Controls the enemy's movement
            transform.Translate(movingDirection * Time.deltaTime * jumpForce);
        }

        //Controls the enemy's movement
        //transform.Translate(movingDirection * Time.deltaTime * moveSpeed);
    }
    
}
