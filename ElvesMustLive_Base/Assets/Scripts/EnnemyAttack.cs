using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyAttack : MonoBehaviour {
	public float TimeBetweenAttacks = 1.5f;
	public int AttackDamage = 10;
	Animator anim;
	GameObject player;
	int playerhealth;
	EnnemyHealth ennemyhealth;
	bool PlayerInRange;
	float timer;
	EnnemyMov1 EnnemyMov1;
	float Distance;
	NavMeshAgent nav;

	void Start ()
	{
		PlayerInRange = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		ennemyhealth = GetComponent<EnnemyHealth> ();
		anim = GetComponent<Animator> ();
		EnnemyMov1 = GetComponent<EnnemyMov1> ();
		nav = GetComponent<NavMeshAgent> ();
	}

	void FixedUpdate () 
	{
		if (nav.enabled == true) 
		{
			Distance = EnnemyMov1.GetDistance ();
			timer += Time.deltaTime;
			if (Distance <= 1.5f)
			{
				nav.enabled = false;
				anim.SetBool ("InMov", false);
				if (timer >= 1.5f) 
				{
					Attack ();
					timer = 0f;
					Debug.Log("Attack");
				}
			}
			if (Distance > 1.5f) 
			{
				if (nav.enabled == false) 
				{
					nav.enabled = true;
					anim.SetBool ("InMov", true);
				}
			}
		}
	}
	void Attack ()
	{
		if (/*playerhealth > 0*/true) 
		{
			anim.SetBool ("Engage",true);
			//playerhealth -= AttackDamage;
			anim.SetBool("InMov",false);
			anim.SetBool ("Engage",false);
		}
	}
}
