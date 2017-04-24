using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_explosion : MonoBehaviour {


	public GameObject explosion;
	public GameObject[] list;

    public int propri;

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Shootable") 
		{
			Explode (coll);
		}
	}
	
	void Explode (Collider coll)
	{
        GameObject temp = null;
        foreach (GameObject pos in list)
		{
			temp = Instantiate (explosion, pos.transform.position, pos.transform.rotation);
            temp.GetComponent<Explosion_damage>().propri = propri;
			Destroy (temp, 1);
		}
        temp.GetComponent<Explosion_damage>().PlaySound(); // Comme ca uniquement le dernier fait du bruit...
		Destroy (gameObject);
	}
}
