using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer_hit : MonoBehaviour {

	bool IsFalling;
	Quaternion objectif;
	bool IsElevating;
	int damage;
	float crushtimer;
	float reloadtimer;
	float i;

	void Awake () 
	{
		IsElevating = false;
		IsFalling = false;
		objectif = transform.rotation;
		objectif.Set (0, 0, 0, 0);
		crushtimer = 0;
		reloadtimer = 0;
		i = 0;
	}

	void Update () 
	{
		if (IsFalling)
		{
			if (i <= 90) 
			{
				objectif.Set (i, 0, 0, 0);
				transform.rotation = objectif;
				i += 0.25f;
			} 
			else 
			{
				if (crushtimer < 2) {
					crushtimer += Time.deltaTime;
				} 
				else
				{
					crushtimer = 0;
					IsFalling = false;
					IsElevating = true;
				}
			}
		}
		if (IsElevating) 
		{
			if (i > 0) 
			{
				objectif [0] = i;
				transform.rotation = Quaternion.RotateTowards (transform.rotation, objectif, Time.deltaTime);
				i -= 1;
			}
			else 
			{
				if ( reloadtimer < 2) 
				{
					reloadtimer += Time.deltaTime;
				} 
				else
				{
					reloadtimer = 0;
					IsElevating = false;
					IsFalling = false;
					GetComponentInParent<Hammer_fall> ().FinishedFalling ();
					i = 0;
				}
			}
		}
	}

	public void TriggerHit()
	{
		IsFalling = true;
	}

	public void SetDamage(int dmg)
	{
		damage = dmg;
	}

	void OnTriggerEnter(Collider coll)
	{
		if (IsFalling && coll.tag == "Shootable") 
		{
			coll.gameObject.GetComponent<Health> ().TakeDamage (damage);
		}
	}
}
