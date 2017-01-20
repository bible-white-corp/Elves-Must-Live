using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDestination : MonoBehaviour {

	public Transform NextPosition;
	SphereCollider coll;
	EnnemyMov1 script;

	void Start () 
	{
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Shootable")
		{
			script = coll.GetComponent<EnnemyMov1> ();
			script.ChangeDestination (NextPosition.gameObject);
			Debug.Log ("change Destination called");
		}
	}
}
