using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnnemyMov1 : MonoBehaviour
{
    public Animator animator;           // Reference to the player's position.
	public NavMeshAgent nav;               // Reference to the nav mesh agent.
	SphereCollider coll;
	public float distance;
    EnnemyAttack atkscript;
    public GameObject player;

	void Awake ()
	{
		// Set up the references.
		coll = GetComponent<SphereCollider> ();
		nav = GetComponent <NavMeshAgent> ();
		animator = GetComponent<Animator> ();
        atkscript = GetComponent<EnnemyAttack>();
        atkscript.enabled = false;
		distance = 5;
	}
			

	void OnTriggerEnter(Collider coll)
	{
		
        
		if (coll.tag == "Player")
		{
			Debug.Log ("Ca marche");
            player = coll.gameObject; // Mieux qu'un Find.
            atkscript.playerhp = player.GetComponent<Health>(); // On envoie le component vie au script d'atk #Thetoto
            atkscript.enabled = true;
            nav.enabled = true;
			animator.SetBool ("InMov", true);

		}
	}
	void OnTriggerStay(Collider coll)
	{
		if (coll.tag == "Player")
		{
			distance = Vector3.Distance (player.transform.position, gameObject.transform.position);
            if (nav.enabled)
            {
                nav.SetDestination(player.transform.position);
                
            }
            
		}
	}

	void OnTriggerExit(Collider coll)
	{
		if (coll.tag =="Player")
		{
			nav.enabled = false;
			animator.SetBool ("InMov", false);
            atkscript.enabled = false;
		}
	}

}