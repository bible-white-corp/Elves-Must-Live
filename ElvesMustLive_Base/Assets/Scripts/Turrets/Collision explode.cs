using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisionexplode : 
MonoBehaviour {

	public int damage;
	Transform bulletpos;
	GameObject explosion;
	float timer;

	void Start () 
	{
		damage = 15;
		timer = 0;
	}

	public void SetExplosion(GameObject explo)
	{
		explosion = explo;
	}
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if (timer >= 1) 
		{
			autodestruct ();
		}
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
		this.gameObject.GetComponent<MeshRenderer> ().enabled = false;
		GameObject boum = Instantiate (explosion,gameObject.transform.position,gameObject.transform.rotation) as GameObject;
		Destroy (boum, 1);
		autodestruct ();

	}
	void autodestruct()
	{
		Destroy (gameObject);
	}
}
