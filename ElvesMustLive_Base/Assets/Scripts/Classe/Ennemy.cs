using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Ennemy : Character
{
    UnityEngine.Object characterprefab = Resources.Load("ennemy");
    Animator animator;
    Transform player;               // Reference to the player's position.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    SphereCollider coll;

    public Ennemy()
    {
        health = 30;
        characterobject = (GameObject)Instantiate(characterprefab);
        coll = GetComponent<SphereCollider>();
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

        // TRIGGER =
    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Tets");
        if (coll.tag == "Player")
        {
            Debug.Log("Trigger Enter");
            player = GameObject.FindGameObjectWithTag("Player").transform;
            nav.enabled = true;
            animator.SetBool("InMov", true);
        }
    }
    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Player")
        {
            nav.SetDestination(player.position);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            nav.enabled = false;
            animator.SetBool("InMov", false);
        }
    }
    // END TRIGGER
}

