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
	float fallingtime;
	float downtime;
	float reloadtime;
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
				transform.localRotation = Quaternion.Euler (new Vector3 (i, 0, 0));
				i += Time.deltaTime * (1f/fallingtime) *90; ;
			} 
			else 
			{
				if (crushtimer < downtime) 
				{
					crushtimer += Time.deltaTime;
				} 
				else
				{
					crushtimer = 0;
					IsFalling = false;
					IsElevating = true;
					i = 89;
				}
			}
		}
		if (IsElevating) 
		{
			if (i > 0) 
			{
				transform.localRotation = Quaternion.Euler (new Vector3 (i, 0, 0));
				i -= 1;
			}
			else 
			{
				if ( reloadtimer < reloadtime) 
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

	public void SetTimes(float fallingtime, float downtime, float reloadtime)
		{
		this.fallingtime = fallingtime;
		this.downtime = downtime;
		this.reloadtime = reloadtime;
		}
	public void SetDamage(int dmg)
	{
		damage = dmg;
	}

	void OnTriggerEnter(Collider coll)
	{
		if (PhotonNetwork.isMasterClient && IsFalling && coll.tag == "Shootable")
        // Que le master inflige qui va ensuite retransmettre aux autres (pour pas dupliquer les dégats et bien synchro)
        {
            coll.gameObject.GetComponent<Health> ().TakeDamage (damage);
		}
	}
}
