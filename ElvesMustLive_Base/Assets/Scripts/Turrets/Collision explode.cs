using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisionexplode : MonoBehaviour {

	ParticleSystem explo;
	public int damage;
	void Start () 
	{
		damage = 15;
		explo = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Shootable") 
		{
			Debug.Log ("enters");
			Explode (coll);
		}
	}

	void Explode(Collider coll)
	{
		var script = coll.GetComponent<Health> ();
		script.TakeDamage (damage);
		Destroy (gameObject);
	}
}
