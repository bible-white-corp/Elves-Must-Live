using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyHealth : MonoBehaviour 
{
	public int health;
	Animator anim;
	public float sinkspeed = 2.5f;
	CapsuleCollider CapsColl;
	bool IsSinking;
	bool IsDead;
	NavMeshAgent nav;

	void Start () 
		{
			health = 30;
			anim = GetComponent<Animator> ();
			CapsColl = GetComponent<CapsuleCollider> ();
			nav = GetComponent<NavMeshAgent> ();
		}

		void Update()
		{
			if(IsSinking)
			{
				// c'est le machin qui fait fondre l'ennemi
				transform.Translate (-Vector3.up * sinkspeed * Time.deltaTime);
				if (Input.GetKey("k"))
				{
					TakeDamage (30);
				}
			}
		}

		public void TakeDamage(int amount)
		{
			if (IsDead)
			{
				return;
			}
			health -= amount;

			if(health <= 0)
			{
				Death ();
			}
		}
		void Death ()
		{
			IsDead = true;
			CapsColl.isTrigger = true;
			anim.SetBool ("Dead", true);
			StartSinking ();
		}
		public void StartSinking ()
		{
			nav.enabled = false;
			GetComponent <Rigidbody> ().isKinematic = true;
			IsSinking = true;
			Destroy (gameObject, 2f);
		}
}
