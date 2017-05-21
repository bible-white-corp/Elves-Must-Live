using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cine_intro_script : MonoBehaviour {

	float timer = 0f;
	bool engageddialogue1 = true;
	public GameObject origine;
	bool engageddialogue2 = true;
	bool end = true;
	bool arrowlauch = true;
	AudioSource audioS;
	Animator anim;
	bool fight = true;
	NavMeshAgent nav;
	GameObject orc;
	public GameObject des;
	public Transform sortie;
	void Start () 
	{
		audioS = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
		nav.enabled = false;

	}

	void Update () 
	{
		timer += Time.deltaTime;
		if (timer > 45 && timer < 57 && engageddialogue1) 
		{
			//dialogue1
			engageddialogue1 =false;
			orc = Instantiate(Resources.Load("Ennemy0")as GameObject,origine.transform.position,origine.transform.rotation);
			orc.GetComponent<Health> ().health = 1;
			anim.SetBool ("Talking",true);
		}
		if (timer >= 57 && timer>59 && fight) 
		{
			fight = false;
			LaunchAttack ();
		}
		if (timer >= 60 && arrowlauch ) 
		{
			arrowlauch = false;
			orc.GetComponent<Health> ().SendDamage (10,1);
		}

		if (timer > 65 && engageddialogue2) 
		{
			engageddialogue2 = false;
			anim.SetBool ("Talking",true);//dialogue2
		}
		if (timer > 70 && end) 
		{
			end = false;
			anim.SetBool ("Talking",false);
			anim.SetBool ("Run",true);
			nav.enabled = true;
			nav.SetDestination (des.transform.position);
			Destroy (gameObject, 5f);
		}

	}

	void LaunchAttack()
	{
		anim.SetBool ("Talking",false);
		anim.SetTrigger ("Fight");
	}
}
