using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Joueur : Character {

    Object characterprefab = Resources.Load("Perso");
    GameObject cam;

    public Joueur()
    {
        health = 30;
        characterobject = (GameObject)Instantiate(characterprefab);
    }
    public Joueur(bool camera)
    {
        health = 30;
        characterobject = (GameObject)Instantiate(characterprefab);
        if (camera)
            cam = (GameObject)Instantiate(Resources.Load("CameraRing"));
    }
}
