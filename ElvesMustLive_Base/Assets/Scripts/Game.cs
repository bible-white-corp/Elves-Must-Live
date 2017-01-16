using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    Joueur player1;

    // Use this for initialization
        void Start () {
            player1 = new Joueur();
    }
	
	// Update is called once per frame
	void Update () {
        if (player1.Health == 0)
        {
            player1.death();
            player1 = new Joueur();
        }
        if (Input.GetKey("h"))
        {
            player1.Health -= 10;
            Debug.Log(player1.Health);
        }
	}
}
