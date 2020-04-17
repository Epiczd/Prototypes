using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    //Button the player uses to continue
    [SerializeField] private Button continueButton;

    //Adds listener for the button
    void Start()
    {
        continueButton.onClick.AddListener(OnClick);
    }

    //Executes if the player clicks the button
    void OnClick()
    {
        /* If the player runs out of lives, and reaches gameover,
         * The player can press a continue button, to try again.
         * Pressing this button will reset there coins to whatever it was when they started the level,
         * And the player will respawn at the previous level
         */
        Coin.playerCoins = Coin.coinsAtStart;
        SceneManager.LoadScene(PlayerLocation.currentLevel);
    }
}
