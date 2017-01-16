using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour {

    Object orc_with_cam = Resources.Load("Perso_with_cam");
    public static int health;
    public static GameObject playerobject;

    public Joueur()
    {
        Debug.Log ("test");
        health = 30;
        initprefab = (GameObject)Instantiate(orc_with_cam);
        
    }

    public void death()
    {
        Destroy(playerobject);
    }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
}
