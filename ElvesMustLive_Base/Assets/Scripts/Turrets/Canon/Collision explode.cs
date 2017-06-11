using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisionexplode : 
MonoBehaviour {

    public int damage;
    public int globaldamage;
    Transform bulletpos;
	GameObject explosion;

	float timer;

    public int propri;

	void Start () 
	{
		timer = 0;
	}

	public void SetExplosion(GameObject explo)
	{
		explosion = explo;
	}
    public void SetDirectHitDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetGlobalDamage(int damage)
    {
        this.globaldamage = damage;
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
			Explode (coll);
		}
	}

	void Explode(Collider coll)
	{
		var script = coll.GetComponent<Health> ();
		script.TakeDamage (damage, propri);
		this.gameObject.GetComponent<MeshRenderer> ().enabled = false;
		GameObject boum = Instantiate (explosion,gameObject.transform.position,gameObject.transform.rotation) as GameObject;
        boum.GetComponent<explosionDamage>().propri = propri;
        boum.GetComponent<explosionDamage>().ExplosionDamage = globaldamage;
        Destroy (boum, 1);
		autodestruct ();

	}
	void autodestruct()
	{
		Destroy (gameObject);
	}
}
