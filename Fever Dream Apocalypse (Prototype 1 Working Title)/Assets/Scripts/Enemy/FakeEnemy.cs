using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeEnemy : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        UpdateEnemy(false);
    }

    //Will destroy the enemy if collided by the player
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    //Destorys the enemy if shot
    public void UpdateEnemy(bool discovered)
    {
        if (discovered)
        {
            Destroy(gameObject);
        }
    }
}
