using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDestination : MonoBehaviour {

	public Transform NextPosition;
	Mov script;

	void Start () 
	{
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Shootable")
		{
			script = coll.GetComponentInChildren<Mov> ();
			script.ChangeDestination (NextPosition);
		}
	}
}
