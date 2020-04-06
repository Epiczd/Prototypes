using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed the player moves
    private float moveSpeed = 10f;

    //Lets the player move
    void Update()
    {
        Movement();
    }

    //Uses WSAD/Arrow Keys to move
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed * x);
        transform.Translate(Vector2.up * Time.deltaTime * moveSpeed * y);
    }
}
