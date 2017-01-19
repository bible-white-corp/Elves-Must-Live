using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnnemyMov1 : MonoBehaviour
{
	Animator animator;
	Transform player;               // Reference to the player's position.
	NavMeshAgent nav;               // Reference to the nav mesh agent.
	SphereCollider coll;
	public float distance;
	Transform ennemy;

	void Awake ()
	{
		// Set up the references.
		
		coll = GetComponent<SphereCollider> ();
		nav = GetComponent <NavMeshAgent> ();
		animator = GetComponent<Animator> ();
		distance = 5;
	}
			

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Player")
		{
            player = GameObject.FindGameObjectWithTag("Player").transform;
            nav.enabled = true;
			animator.SetBool ("InMov", true);
			ennemy = GetComponent<Transform> ();
		}
	}
	void OnTriggerStay(Collider coll)
	{
		if (coll.tag == "Player" && nav.enabled==true)
		{
			nav.SetDestination (player.position);
			distance = Vector3.Distance (player.position, ennemy.position);
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
	public float GetDistance()
	{
		return distance;
	}
}