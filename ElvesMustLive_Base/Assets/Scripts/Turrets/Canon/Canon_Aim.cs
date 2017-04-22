using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_Aim : MonoBehaviour {

	public int DirectHitDamage;
	public GameObject currentTarget;
	private Vector3 LastKnownPosition;
	private Quaternion LookAtRotation;
	private Quaternion temporaire;
	public float TurretsSpeed;
	Transform children;
	float timerbeforeshot;
	public float reloadtime;
	Transform sortie;
	public GameObject Bullet;
	Health script;
	bool engage; //ca sert a bidouiller 
	public GameObject explosion;

    public int propri;

    void Start () 
	{
		LastKnownPosition = Vector3.zero;
		timerbeforeshot = 0f;
		engage = false;

        propri = int.Parse(GetComponentInParent<PhotonView>().instantiationData[0].ToString());
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
				Shoot (transform.GetChild (0).GetChild (1));
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
		GameObject Shoot = Instantiate (Bullet,hole.position,hole.rotation) as GameObject;
		Shoot.GetComponent<Rigidbody> ().AddForce (hole.forward * 2500);
		Shoot.AddComponent<Collisionexplode> ();
		Shoot.GetComponent<Collisionexplode> ().SetExplosion (explosion);
        Shoot.GetComponent<Collisionexplode>().propri = propri;
    }
}
