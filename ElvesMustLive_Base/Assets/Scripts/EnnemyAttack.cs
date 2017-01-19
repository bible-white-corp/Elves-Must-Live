using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAttack : MonoBehaviour {
	public float TimeBetweenAttacks = 1.5f;
	public int AttackDamage = 10;
	Animator anim;
	GameObject player;
	int playerhealth;
	EnnemyHealth ennemyhealth;
	bool PlayerInRange;
	float timer;
	EnnemyMov1 EnnemyMov;
	float Distance;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		ennemyhealth = GetComponent<EnnemyHealth> ();
		anim = GetComponent<Animator> ();
	}

	void Update () 
	{
		this.Distance = EnnemyMov.distance;
		timer += Time.deltaTime;
		if (Distance <= 1.5f)
		{
			PlayerInRange = true;
		}
		if (Distance > 1.5f)
		{
			PlayerInRange = false;
		}
		if ((timer >= TimeBetweenAttacks) && (PlayerInRange) &&(ennemyhealth.health > 0))
			{
			Attack();
			}
	}
	void Attack ()
	{
		timer = 0f;
		if (playerhealth > 0) 
		{
			anim.SetBool ("Engage", true);
			playerhealth -= AttackDamage;
			anim.SetBool ("Engage", false);
		}
	}
}
