using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour 
{
	public int health = 30;
	Animator anim;
	public float sinkspeed = 1f;
	bool IsSinking;
	public bool IsDead;
	NavMeshAgent nav;
	Rigidbody body;
	float TimerbeforeDeath;
    public GameObject obj;

    void Start()
    {
        obj = gameObject;
        anim = GetComponent<Animator>();
        //Pour le player qui n'a pas de Nav #Thetoto
        try
        {
            nav = GetComponent<NavMeshAgent>();
        }
        catch { }
    }

    void FixedUpdate()
    {
        if (IsSinking)
        {
			TimerbeforeDeath += Time.deltaTime;
			if (TimerbeforeDeath > 2.5f)
			{
				// c'est le machin qui fait fondre l'ennemi
				transform.Translate (Vector3.down * sinkspeed * Time.deltaTime);
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

        if (health <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        IsDead = true;
		anim.SetBool ("InMov", false);
		anim.SetTrigger ("Died");
        StartSinking();
    }
    public void StartSinking()
    {
        if (nav)
        {
			Destroy (nav);
        }
        try
        {
            GetComponentInChildren<SphereCollider>().enabled = false; // Pour empècher les autres animations... #Thetoto
        }
        catch { }
		body = GetComponent<Rigidbody> ();
        body.isKinematic = true;
        body.constraints = RigidbodyConstraints.None;
        IsSinking = true;
        Destroy(gameObject, 4f);
    }
}
