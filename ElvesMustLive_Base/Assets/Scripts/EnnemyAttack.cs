using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyAttack : MonoBehaviour {
	public float TimeBetweenAttacks = 1.6f;
	public int AttackDamage = 10;
	Animator anim;
    GameObject player;
	Health hp;
	float timer;
	EnnemyMov1 mov1;
	float Distance;
	NavMeshAgent nav;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
		mov1 = GetComponent<EnnemyMov1> ();
		nav = GetComponent<NavMeshAgent> ();
        hp = GetComponent<Health>();
	}

	void Update () 
	{
        // Ceci est actif que quand trigger de mov1 actif.
        Distance = mov1.distance;
		timer += Time.deltaTime;
        if (Distance <= 1.5f)
        {
            if (nav.enabled)
            {
                nav.enabled = false;
                anim.SetBool("InMov", false);
                anim.SetBool("Engage", true);
            }
            if (timer >= 1.5f)
            {
                timer = 0f;
                Debug.Log("On Attack");
                player.GetComponent<Health>().TakeDamage(AttackDamage);
            }

        }
        if (Distance > 1.5f)
        {
            if (!nav.enabled)
            {
                Debug.Log("On atk plus, on marche");
                nav.enabled = true;
                anim.SetBool("InMov", true);
                anim.SetBool("Engage", false);  
            }
        }
	}
}
