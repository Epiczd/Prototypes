using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    //The PlayButton
    [SerializeField] private Button play;

    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(onClick);
    }

    //When the player clicks the playbutton, the first level will load
    void onClick()
    {
        SceneManager.LoadScene("Level1");
    }

}
