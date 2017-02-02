using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Cameras;

public class Game : MonoBehaviour {

    public GameObject player1;
	public FreeLookCam playercam;

    public GameObject fpscam; // Utile dans le script FPSCam !
    public GameObject cam;

    // Use this for initialization
    void Awake () 
	{
        player1 = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("PlayerCamera");
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

        if (Input.GetButton("CenterCam")) //La touche L dans TLoZelda. Pas trouver d'autre examples #Thetoto.
        {
            playercam.LookPlayer(player1.transform.rotation.eulerAngles.y, 15f);

        }

    }

}
