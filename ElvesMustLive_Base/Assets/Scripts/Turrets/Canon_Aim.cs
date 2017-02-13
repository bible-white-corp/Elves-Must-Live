using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_Aim : MonoBehaviour {

	public GameObject currentTarget;
	private Vector3 LastKnownPosition;
	private Quaternion LookAtRotation;
	private Quaternion temporaire;
	public float TurretsSpeed;
	SphereCollider coll;
	Transform children;

	void Start () 
	{
		children = transform.GetChild (0);
		coll = GetComponent<SphereCollider> ();
		LastKnownPosition = Vector3.zero;
	}

	void Update () 
	//il est a noter que ce script a pour seul but de changer l'orientation de la tourelle selon l'axe y!
	{
		if (currentTarget != null)
		{
			if (currentTarget.transform.position != LastKnownPosition) 
			{
				LastKnownPosition = currentTarget.transform.position;
				LookAtRotation = Quaternion.LookRotation (LastKnownPosition - transform.position);
			}
			if (transform.rotation != LookAtRotation) 
			{
				//attention gros bidouillage en approche
				temporaire = transform.rotation;
				temporaire[1] = LookAtRotation.y;
				transform.rotation = Quaternion.RotateTowards(transform.rotation,temporaire,TurretsSpeed* Time.deltaTime);
				transform.GetChild (0).rotation = new Quaternion (LookAtRotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);  
			}
		}
	}
		

	void OnTriggerEnter(Collider coll)
	{
		if (currentTarget == null && coll.tag == "Shootable") 
		{
			currentTarget = coll.gameObject;
			LastKnownPosition = currentTarget.transform.position;
		}
	}
	void OnTriggerStay(Collider coll)
	{
		if (currentTarget == null && coll.tag == "Shootable") 
		{
			currentTarget = coll.gameObject;
			LastKnownPosition = currentTarget.transform.position;
		}
	}
	void OnTriggerExit(Collider coll)
	{
		if (coll.gameObject == currentTarget) 
		{
			currentTarget = null;
		}
	}
}
