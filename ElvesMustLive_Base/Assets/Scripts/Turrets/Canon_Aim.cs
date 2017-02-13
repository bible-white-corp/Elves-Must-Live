using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_Aim : MonoBehaviour {

	public GameObject currentTarget;
	private Vector3 LastKnownPosition;
	private Quaternion LookAtRotation;
	private Quaternion temporaire;
	public float TurretsSpeed;
	SphereCollider coll;
	Transform children;
	float timerbeforeshot;
	public float reloadtime;
	Transform sortie;
	public GameObject Bullet;
	Health script;

	void Start () 
	{
		coll = GetComponent<SphereCollider> ();
		LastKnownPosition = Vector3.zero;
		timerbeforeshot = 0f;
	}

	void Update () 
	//il est a noter que ce script a pour seul but de changer l'orientation de la tourelle selon l'axe y!
	{
		if (currentTarget != null)
		{
			if (currentTarget.transform.position != LastKnownPosition) 
			{
				LastKnownPosition = currentTarget.transform.position;
				LookAtRotation = Quaternion.LookRotation (LastKnownPosition - transform.position);
			}
			if (transform.rotation != LookAtRotation) 
			{
				//attention gros bidouillage en approche
				temporaire = transform.rotation;
				temporaire[1] = LookAtRotation.y;
				transform.rotation = Quaternion.RotateTowards(transform.rotation,temporaire,TurretsSpeed* Time.deltaTime);
				transform.GetChild (0).rotation = new Quaternion (LookAtRotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);  
			}
			timerbeforeshot += Time.deltaTime;
			if (timerbeforeshot > reloadtime) 
			{
				Shoot (transform.GetChild (0).GetChild (1));
				timerbeforeshot = 0f;
			}
		}
	}
		

	void OnTriggerEnter(Collider coll)
	{
		if (currentTarget == null && coll.tag == "Shootable") 
		{
			currentTarget = coll.gameObject;
			LastKnownPosition = currentTarget.transform.position;
			script = coll.GetComponent<Health> ();
		}
	}
	void OnTriggerStay(Collider coll)
	{
		if (currentTarget == null && coll.tag == "Shootable") 
		{
			currentTarget = coll.gameObject;
			LastKnownPosition = currentTarget.transform.position;
			script = coll.GetComponent<Health> ();
		}
		if (script.health <= 0) 
		{
			currentTarget = null;
		}

	}
	void OnTriggerExit(Collider coll)
	{
		if (coll.gameObject == currentTarget) 
		{
			currentTarget = null;
		}
	}

	void Shoot(Transform hole)
	{
		GameObject Shoot = Instantiate (Bullet,hole.position,hole.rotation) as GameObject;
		Shoot.GetComponent<Rigidbody> ().AddForce (hole.forward * 2500);
		Shoot.AddComponent<Collisionexplode> ();
		Destroy (Shoot, 2);
	}
}
