using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnnemyMovement : MonoBehaviour
{
	Animator animator;
	Transform player;               // Reference to the player's position.
	//PlayerHealth playerHealth;       Reference to the player's health.
	//EnemyHealth enemyHealth;         Reference to this enemy's health.
	NavMeshAgent nav;               // Reference to the nav mesh agent.
	SphereCollider coll;

	void Awake ()
	{
		// Set up the references.
		
		coll = GetComponent<SphereCollider> ();
		//playerHealth = player.GetComponent <PlayerHealth> ();
		//enemyHealth = GetComponent <EnemyHealth> ();
		nav = GetComponent <NavMeshAgent> ();
		animator = GetComponent<Animator> ();
	}
	void Start ()
	{

	}


	void Update ()
	{
		
	}
			

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Player")
		{
            player = GameObject.FindGameObjectWithTag("Player").transform;
            nav.enabled = true;
			animator.SetBool ("InMov", true);
		}
	}
	void OnTriggerStay(Collider coll)
	{
		if (coll.tag == "Player")
		{
			nav.SetDestination (player.position);
		}
	}

	void OnTriggerExit(Collider coll)
	{
		if (coll.tag =="Player")
		{
			nav.enabled = false;
			animator.SetBool ("InMov", false);
		}
	}
}