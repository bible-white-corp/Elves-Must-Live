using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AssasMov : MonoBehaviour {

	public Animator animator;           // Reference to the player's position.
	public NavMeshAgent nav;               // Reference to the nav mesh agent.
	public float distance;
	AssasAttack atkscript;
	Health hp;
	public GameObject player;
	public Transform Destination;
	bool engaged = false;
	PlayerHealth plyHP;
	//InitiateDestination initiate;


	void Awake ()
	{
		// Set up the references.
		nav = GetComponentInParent<NavMeshAgent> (); 
		animator = GetComponentInParent<Animator> ();
		atkscript = GetComponentInChildren<AssasAttack>();
		hp = GetComponentInParent<Health>();
		atkscript.enabled = false;
		distance = 5;	
		//initiate = GetComponent <InitiateDestination> ();
	}
	void Start()    
	{
		//initiate.enabled = true;
		//nav.enabled = true;
		animator.SetBool ("InMov", true);
	}
	void Update()
	{
		if (!hp.IsDead && engaged)
		{
			distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
			if (nav.enabled)
			{
				nav.SetDestination(player.transform.position);
			}
		}
	}


	void OnTriggerEnter(Collider coll)
	{


		if (coll.tag == "Player")
		{
			player = coll.gameObject;
			nav.speed = 3;
			atkscript.playerhp = player.GetComponent<PlayerHealth>(); // On envoie le component vie au script d'atk #Thetoto
			atkscript.enabled = true;

		}
	}
	void OnTriggerStay(Collider coll)
	{
		if (coll.tag == "Player")
		{
			if( !hp.IsDead && !engaged) 
		{
				engaged = true;
			plyHP = coll.GetComponent<PlayerHealth>();
			}
			if (coll.tag == "Player" && engaged && plyHP.IsDead) 
		{
				distance = Vector3.Distance (player.transform.position, gameObject.transform.position);
				engaged = false;
				if (nav.enabled) {
					nav.SetDestination (Destination.position);
					atkscript.enabled = false;

					nav.speed = 2;
				}
			}
		}
	}
	public void ChangeDestination(Transform newgameObject)
	{
		nav.SetDestination (newgameObject.position);
		Destination = newgameObject;
	}
}
