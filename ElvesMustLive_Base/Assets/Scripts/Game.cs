﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Cameras;

public class Game : MonoBehaviour {

    public static GameObject player1;
	FreeLookCam playercam;

    // Use this for initialization
    void Start () 
	{
        player1 = GameObject.FindGameObjectWithTag("Player");
		GameObject cam = GameObject.FindGameObjectWithTag ("PlayerCamera");
		playercam = cam.GetComponent<FreeLookCam> ();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("h"))
        {
            player1.GetComponent<PlayerHealth>().TakeDamage(30);
        }

        if (Input.GetKey("k"))
        {
            GameObject.FindGameObjectWithTag("Shootable").GetComponent<Health>().TakeDamage(31);
        }

		if (Input.GetKeyDown("j"))
        {
            Instantiate(Resources.Load("Ennemy"));
        }
        if (Input.GetKey("t"))
        {
            if (player1 == null)
            {
                player1 = (GameObject)Instantiate(Resources.Load("Perso"));
				playercam.enabled = true;
            }
        }

    }

}
