using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnnemyMovement : MonoBehaviour
{
	Transform player;               // Reference to the player's position.
	//PlayerHealth playerHealth;       Reference to the player's health.
	//EnemyHealth enemyHealth;         Reference to this enemy's health.
	NavMeshAgent nav;               // Reference to the nav mesh agent.
	SphereCollider coll;

	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		coll = GetComponent<SphereCollider> ();
		//playerHealth = player.GetComponent <PlayerHealth> ();
		//enemyHealth = GetComponent <EnemyHealth> ();
		nav = GetComponent <NavMeshAgent> ();
	}
	void Start ()
	{
	}


	void Update ()
	{
		//if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		if (OnTriggerEnter(coll)==true)
		{
			Debug.Log ("destination set");
			nav.SetDestination (player.position);
		}

		if (OnTriggerExit(coll)==true)
		{
		Debug.Log ("destination unset");
		nav.enabled = false;
		}
	} 
	bool OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Player")
		{
			Debug.Log (" enter");
			return true;
		}
		return false;
	}

	bool OnTriggerExit(Collider coll)
	{
		if (coll.tag =="Player")
		{
			return true;
		}
		return false;
	}
}