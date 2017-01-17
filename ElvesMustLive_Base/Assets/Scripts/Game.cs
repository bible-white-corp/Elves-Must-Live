using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game : MonoBehaviour {

    Joueur player1;
    Ennemy en;
    [SerializeField] bool SummonPlayer1 = true;
    [SerializeField] bool WithCamera = true;
    [SerializeField] bool SummonEnnemies = false;
    [SerializeField] int NombresEnnemies = 1;

    Ennemy ennemyobj;

    // Use this for initialization
    void Start () {
        if (SummonPlayer1)
            player1 = new Joueur(WithCamera);
        if (SummonEnnemies)
            for (int i = 0; i < NombresEnnemies; i++)
            {
                en = new Ennemy();
            }
        }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("h"))
        {
            player1.Health -= 10;
            Debug.Log(player1.Health);

            if (player1.CheckDeath())
            {
                player1 = new Joueur(WithCamera);
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
    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Tets");
        if (coll.tag == "Player")
        {
            Debug.Log("Trigger Enter");
        }
    }
}
