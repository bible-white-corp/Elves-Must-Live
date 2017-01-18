using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Joueur : Character {

    Object characterprefab = Resources.Load("Perso");


    public Joueur()
    {
        health = 30;
        characterobject = (GameObject)Instantiate(characterprefab);
        
    }

}
