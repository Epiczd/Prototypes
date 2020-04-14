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
        print(jumpTime);
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

        if(canJump == false)
        {
            //Controls the enemy's movement
            transform.Translate(movingDirection * Time.deltaTime * moveSpeed);
        }

        /*
        if (canJump && jumpTime > 0f)
        {
            //Controls the enemy's movement
            transform.Translate(movingDirection * Time.deltaTime * moveSpeed);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            jumpForce -= Time.deltaTime;
        }
        else if(canJump && jumpTime <= 0f)
        {
            //Controls the enemy's movement
            transform.Translate(movingDirection * Time.deltaTime * moveSpeed);
        }
        */

        if (canJump)
        {
            switch (jumpTime)
            {
                case 1f:
                    //Controls the enemy's movement
                    transform.Translate(movingDirection * Time.deltaTime * moveSpeed);
                    gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
                    jumpForce -= Time.deltaTime;
                    break;
                case 0f:
                    transform.Translate(movingDirection * Time.deltaTime * moveSpeed);
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (canJump)
        {
            if (collision.CompareTag("Ground"))
            {
                jumpTime = 1f;
            }
        }
    }
}
