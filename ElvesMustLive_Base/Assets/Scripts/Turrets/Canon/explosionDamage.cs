using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDamage : MonoBehaviour {

	public int ExplosionDamage;

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Shootable") 
		{
			coll.GetComponent<Health> ().TakeDamage (ExplosionDamage);
			Debug.Log ("Damaged");
		}
	}
}
