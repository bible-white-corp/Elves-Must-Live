using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnnemyMov1 : Mov
{

    EnnemyAttack atkscript;

	//InitiateDestination initiate;


	void Awake ()
	{
		// Set up the references.
		nav = GetComponentInParent<NavMeshAgent> (); 
		animator = GetComponentInParent<Animator> ();
        atkscript = GetComponentInChildren<EnnemyAttack>();
        hp = GetComponentInParent<Health>();
        //atkscript.enabled = false;
		distance = 5;	
		//initiate = GetComponent <InitiateDestination> ();
	}
	void Start()    
	{
		//initiate.enabled = true;
		//nav.enabled = true;
		//animator.SetBool ("InMov", true);
	}
	void Update()
	{
        
	}
			

	void OnTriggerEnter(Collider coll)
	{
		
        
		if (coll.tag == "Player")
		{
            player = coll.gameObject;
            atkscript.playerhp = player.GetComponent<PlayerHealth>(); // On envoie le component vie au script d'atk #Thetoto
            atkscript.enabled = true;

		}
	}
	void OnTriggerStay(Collider coll)
	{
        if (coll.tag == "Player" && !hp.IsDead)
        {
            distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
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
			nav.SetDestination (Destination.position);
            atkscript.enabled = false;
		}
	}
	public override void ChangeDestination(Transform newgameObject)
	{
		nav.SetDestination (newgameObject.position);
		Destination = newgameObject;
	}

}