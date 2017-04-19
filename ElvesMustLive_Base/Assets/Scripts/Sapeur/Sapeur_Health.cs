using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sapeur_Health : Photon.MonoBehaviour {


	bool Dead;
	Health script;
	GameObject boum;
	public GameObject SAPEUR_explosion;
	public GameObject TNT;

	void Start()
	{
		Dead = false;
		script = GetComponent<Health> ();
	}

	void FixedUpdate()
	{
		if (!Dead && script.health <= 0) 
		{
			Dead = true;
			boum = Instantiate (SAPEUR_explosion, TNT.transform.position, TNT.transform.rotation);
			Destroy (TNT);
			Destroy (boum, 1);
		}
	}
}
