using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer_fall : MonoBehaviour {

	bool IsFalling;
	public int hammerdamage;
	void Start () 
	{
		IsFalling = false;
		GetComponentInChildren<Hammer_hit> ().SetDamage (hammerdamage);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider coll)
	{
		if (!IsFalling)
		{
			if (coll.tag == "Shootable") 
			{
				transform.GetChild(0).GetComponent<Hammer_hit>().TriggerHit ();
				IsFalling = true;
			}

		}
	}

	public void FinishedFalling()
	{
		IsFalling = false;
	}
}
