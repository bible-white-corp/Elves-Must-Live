using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipLvl : MonoBehaviour {

    Game game;

	// Use this for initialization
	void Start () {
        game = GetComponent<Game>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) && game.cheats && PlayerPrefs.GetString("Mode") == "History")
        {
            GetComponent<WaveGenerator>().winner = true;
            GetComponent<WaveGenerator>().endGame = true;

        }
    }
}
