using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    //The max position the platform can fall to
    [SerializeField] private float maxFall;

    //The Falling Platform
    [SerializeField] private Rigidbody2D fallingPlatform;

    //Starting position of the platform
    private Vector3 startPos;

    //Checks if the platform is falling
    private bool falling = false;

    //Set's the starting position
    void Start()
    {
        startPos = this.transform.position;
    }

    //If the platform reaches its max fall value, it returns to it's original position
    void Update()
    {
        Fall();

        print(falling);

        if(this.transform.position.y <= maxFall)
        {
            falling = false;
            this.transform.position = startPos;
        }
    }

    //Checks for entering the collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        //When the player jumps on the falling platform, it will start falling
        if(collision.collider.tag == "Player")
        {
            falling = true;
        }
    }

    //Checks for collision, while on the collider
    void OnCollisionStay2D(Collision2D collision)
    {
        //While the player is on the platform, it will continue falling
        if(collision.collider.tag == "Player")
        {
            falling = true;
        }
    }

    /* Method that determines if the platform is falling.
     * If falling is true, the platform will fall,
     * If falling is false, the platform will stop falling, and return to it's original position
     */
    void Fall()
    {
        if (falling)
        {
            fallingPlatform.isKinematic = false;
            fallingPlatform.constraints = RigidbodyConstraints2D.None;
            fallingPlatform.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            fallingPlatform.isKinematic = true;
            fallingPlatform.constraints = RigidbodyConstraints2D.FreezePositionY;
            fallingPlatform.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
