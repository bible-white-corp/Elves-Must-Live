using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{

    Object ennemyprefab = Resources.Load("ennemy");
    public static int health;
    public static GameObject ennemyobject;

    public Ennemy()
    {
        health = 30;
        ennemyobject = (GameObject)Instantiate(ennemyprefab);

    }

    public void death()
    {
        Destroy(ennemyobject);
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
