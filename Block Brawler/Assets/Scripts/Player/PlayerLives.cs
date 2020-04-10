using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    //Amount of lives the player has
    protected static int lives = 3;

    //On Start, the player has three lives
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //If the player runs out of lives, it's gameover
        if(lives <= 0)
        {
            GameOver();
        }
    }

    //Executed when the player losses all of it's lives
    void GameOver()
    {
        //Loads the gameover screen
        SceneManager.LoadScene("GameOver");
    }
}
