using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : MonoBehaviour {

	public GameObject regenparticules;
	public int RegenPerSecond;
	float timer;

	void Start()
	{
		timer = 0;
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Player") 
		{
			Vector3 position = coll.transform.position;
			position.y += 1;
			Instantiate (regenparticules, position, Quaternion.identity ,coll.transform);
		}
	}

	void OnTriggerStay(Collider coll)
	{
		if (coll.tag == "Player") 
		{
			timer += Time.deltaTime;
			if (timer >= 1) 
			{
				PlayerHealth vie = coll.GetComponent<PlayerHealth> ();
				if (vie.maxhealth > vie.health)
				{
					vie.health += RegenPerSecond;
				}
				timer = 0;
			}
		}
	}

	void OnTriggerExit(Collider coll)
	{
		if (coll.tag == "Player")
			{
			Destroy(coll.transform.Find("regenParticule 1(Clone)").gameObject);
			}
	}
}
