using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDamage : MonoBehaviour {

	public int ExplosionDamage;

	void OnTriggerEnter(Collider coll)
	{
		if (PhotonNetwork.isMasterClient && coll.tag == "Shootable")
        // Que le master inflige qui va ensuite retransmettre aux autres (pour pas dupliquer les dégats et bien synchro)
        {
            coll.GetComponent<Health> ().TakeDamage (ExplosionDamage);
		}
	}
}
