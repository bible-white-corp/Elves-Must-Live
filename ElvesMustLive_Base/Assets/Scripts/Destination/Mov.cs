using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mov : MonoBehaviour {

    public Animator animator;           // Reference to the player's position.
    public UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
    public float distance;
    protected Health hp;
    public GameObject player;
    public Transform Destination;
    public abstract void ChangeDestination(Transform newgameObject);
}
