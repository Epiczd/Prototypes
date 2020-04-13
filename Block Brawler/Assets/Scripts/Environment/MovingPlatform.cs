using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //Determines if the platform is moving horizontally or vertically
    [SerializeField] private bool horizontal;

    //Used if the platform is moving horizontally
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;

    //Used if the platform is moving vertically
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;

    //Speed the platform moves
    [SerializeField] private float movementSpeed;

    //The Player
    [SerializeField] private Transform player;

    //Direction the platform is moving
    private Vector2 movingDirection;

    //On start, the moving direction is set
    void Start()
    {
        if (horizontal)
        {
            movingDirection = Vector2.left;
        }
        else
        {
            movingDirection = Vector2.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    //Updates the platforms movement
    void Movement()
    {
        //Checks if the platform moves horizontally or vertically
        if (horizontal)
        {
            //Checks which direction the platform should move
            if(transform.position.x > xMax)
            {
                movingDirection = Vector2.left;
            }
            else if(transform.position.x < xMin)
            {
                movingDirection = Vector2.right;
            }
        }
        else
        {
            //Checks which direction the platform should move
            if(transform.position.y > yMax)
            {
                movingDirection = Vector2.down;
            }
            else if(transform.position.y < yMin)
            {
                movingDirection = Vector2.up;
            }
        }

        //Moves the platform
        transform.Translate(movingDirection * Time.deltaTime * movementSpeed);
    }

    //Checks when the player enters the platform
    void OnCollisionEnter2D(Collision2D collision)
    {
        //When the player enters the platform, they will move with the platform
        if(collision.collider.tag == "Player")
        {
            player.transform.Translate(movingDirection * Time.deltaTime * movementSpeed);
        }
    }

    //Checks while the player is on the platform
    void OnCollisionStay2D(Collision2D collision)
    {
        //While the player is on the platform, they will move with the platform
        if (collision.collider.tag == "Player")
        {
            player.transform.Translate(movingDirection * Time.deltaTime * movementSpeed);
        }
    }
}
