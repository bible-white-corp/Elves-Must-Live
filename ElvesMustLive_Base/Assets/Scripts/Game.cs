using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game : MonoBehaviour {

    Joueur player1;
    GameObject cam;
    [SerializeField] bool SummonPlayer1 = true;
    [SerializeField] bool SummonEnnemies = false;
    [SerializeField] int NombresEnnemies = 1;

    Ennemy ennemyobj;

    // Use this for initialization
    void Start () {
        cam = (GameObject)Instantiate(Resources.Load("CameraRig")); // La caméra va TOUJOURS suivre le joueur, même si il meurt, et revient après. Super joli en plus.
        if (SummonPlayer1)
            player1 = new Joueur();
        if (SummonEnnemies)
            for (int i = 0; i < NombresEnnemies; i++)
            {
                new Ennemy();
            }
        }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("h"))
        {
            player1.Health -= 10;

            if (player1.CheckDeath())
            {
                player1 = new Joueur();
            }
        }

        if (Input.GetKey("k"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Shootable"))  ;
        }
        if (Input.GetKey("j"))
        {
            new Ennemy();
        }
        if (Input.GetKey("t"))
        {
            
        }

    }

}
