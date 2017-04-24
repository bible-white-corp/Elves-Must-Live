using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_damage : MonoBehaviour {

	public int damage;

    public int propri;

    public void PlaySound()
    {
        GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sound/RocketExplode"));
    }

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Shootable") 
		{
			coll.GetComponent<Health> ().TakeDamage (damage, propri);
		}
	}
}
