using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    
    Game game;

    private void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<Game>();
    }

    public void PauseGame()
    {
        game.PauseGame();
    }
}
