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
	public GameObject Destination;
	//InitiateDestination initiate;


	void Awake ()
	{
		// Set up the references.
		nav = GetComponentInParent<NavMeshAgent> (); 
		animator = GetComponentInParent<Animator> ();
        atkscript = GetComponentInParent<EnnemyAttack>();
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
			
	}
			

	void OnTriggerEnter(Collider coll)
	{
		
        
		if (coll.tag == "Player")
		{
            player = coll.gameObject; // Mieux qu'un Find.
            atkscript.playerhp = player.GetComponent<PlayerHealth>(); // On envoie le component vie au script d'atk #Thetoto
            atkscript.enabled = true;

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
			nav.SetDestination (Destination.transform.position);
            atkscript.enabled = false;
		}
	}
	public void ChangeDestination(GameObject newgameObject)
	{
		nav.SetDestination (newgameObject.transform.position);
		Destination = newgameObject;
		Debug.Log ("Change Destination called");
	}

}