using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal_aim : MonoBehaviour {

	public int DirectHitDamage;
	GameObject currentTarget;
	private Vector3 LastKnownPosition;
	public float TurretsSpeed;
	Transform children;
	float timerbeforeshot;
	public float reloadtime;
	Transform sortie;
	LineRenderer laser;
	Health script;
	float laserTime;
	public GameObject LaserFrom;
	bool engage; //ca sert a bidouiller 

	void Start () 
	{
		laser = GetComponent<LineRenderer> ();
		LastKnownPosition = Vector3.zero;
		timerbeforeshot = 0f;
		laserTime = 0f;
		engage = false;
		laser.enabled = false;
	}

	void Update () 

	{
		if (currentTarget != null) {

			var targetRotation = Quaternion.LookRotation (currentTarget.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, TurretsSpeed * Time.deltaTime);

			timerbeforeshot += Time.deltaTime;
			if (timerbeforeshot > reloadtime) {
				laser.enabled = true;
				laser.SetPosition (0, LaserFrom.transform.position);
				laser.SetPosition (1, (new Vector3 (currentTarget.transform.position.x, currentTarget.transform.position.y + 1, currentTarget.transform.position.z)));
				timerbeforeshot = 0f;
				script.TakeDamage (DirectHitDamage);
			} 
		}
		if (laser.enabled && laserTime < 0.1f) 
			{
				laserTime += Time.deltaTime;
			} 
		else 
			{
				laser.enabled = false;
				laserTime = 0f;
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
			laser.enabled = false;
		}

	}
	void OnTriggerExit(Collider coll)
	{
		if (coll.gameObject == currentTarget) 
		{
			currentTarget = null;
			engage = false;
			if (laser.enabled) 
			{
				laser.enabled = false;
			}
		}
	}


}
