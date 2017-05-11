using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtalScript : MonoBehaviour {

    Game game;

	// Use this for initialization
	void Start () {
        game = GameObject.Find("GameManager").GetComponent<Game>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Shootable")
        {
            // Un ennemie est passé
            game.globalLife -= 1;
            Destroy(coll.gameObject);
        }
    }
}
