using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_damage : MonoBehaviour {

	public int damage;
	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Shootable") 
		{
			coll.GetComponent<Health> ().TakeDamage (damage);
		}
	}
}
