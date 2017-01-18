using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    
    public int health;
    public GameObject characterobject;

    public Character()
    {
    }

    public void Death()
    {
        Destroy(characterobject);
        Debug.Log("Mort.");
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    public bool CheckDeath()
    {
        if (Health <= 0)
        {
            Death();
            return true;
        }
        return false;
    }
}
