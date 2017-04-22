using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sapeur_Mov : Mov {

    

	//InitiateDestination initiate;


	void Awake ()
	{
		// Set up the references.
		nav = GetComponentInParent<NavMeshAgent> (); 
		animator = GetComponentInParent<Animator> ();
		hp = GetComponentInParent<Health>();
		distance = 5;	
		nav.speed = 4;
		//initiate = GetComponent <InitiateDestination> ();
	}
	void Start()    
	{
		//initiate.enabled = true;
		//nav.enabled = true;
		animator.SetBool ("InMov", true);
		animator.SetBool ("Engage",false);
	}


	public override void ChangeDestination(Transform newgameObject)
	{
		nav.SetDestination (newgameObject.position);
		Destination = newgameObject;
	}

}
