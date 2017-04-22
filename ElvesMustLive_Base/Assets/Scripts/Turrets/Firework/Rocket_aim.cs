using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_aim : MonoBehaviour {

	public int DirectHitDamage;
	public GameObject currentTarget;
	private Vector3 LastKnownPosition;
	private Quaternion temporaire;
	public float TurretsSpeed;
	Transform children;
	float timerbeforeshot;
	public float reloadtime;
	public Transform sortie;
	public GameObject Bullet;
	Health script;
	bool engage; //ca sert a bidouiller 
	public GameObject explosion;

	void Start () 
	{
		LastKnownPosition = Vector3.zero;
		timerbeforeshot = 0f;
		engage = false;
	}

	void Update () 

	{
		if (currentTarget != null)
		{

			var targetRotation = Quaternion.LookRotation(currentTarget.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurretsSpeed * Time.deltaTime);

			timerbeforeshot += Time.deltaTime;
			if (timerbeforeshot > reloadtime) 
			{
				Shoot (sortie);
				timerbeforeshot = 0f;
			}
		}
	}


	void OnTriggerEnter(Collider coll)
	{
		if (engage == false && coll.tag == "Shootable") 
		{
			currentTarget = coll.gameObject;
			LastKnownPosition = currentTarget.transform.position;
			script = coll.GetComponent<Health> ();
			engage = true;
		}
	}
	void OnTriggerStay(Collider coll)
	{
		if (engage==false && coll.tag == "Shootable") 
		{
			currentTarget = coll.gameObject;
			LastKnownPosition = currentTarget.transform.position;
			script = coll.GetComponent<Health> ();
			engage = true;
		}
		if (engage && script.health <= 0) 
		{
			currentTarget = null;
			engage = false;
		}

	}
	void OnTriggerExit(Collider coll)
	{
		if (coll.gameObject == currentTarget) 
		{
			currentTarget = null;
			engage = false;
		}
	}

	void Shoot(Transform hole)
	{
		Quaternion temp = new Quaternion (transform.rotation.x,transform.rotation.y,transform.rotation.z,transform.rotation.w) * Quaternion.AngleAxis(90,Vector3.up);
		//bidouillage de l'extreme a cause du prefab de la rocket qui est à l'envers de base #Nat
		GameObject Shoot = Instantiate (Bullet,hole.position,temp) as GameObject;
		Shoot.GetComponent<Rigidbody> ().AddForce (hole.up * 1200); 
		Destroy (Shoot, 1);
	}
}
