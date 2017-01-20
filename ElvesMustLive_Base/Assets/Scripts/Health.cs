using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour 
{
	public int health = 30;
	Animator anim;
	public float sinkspeed = 2.5f;
	bool IsSinking;
	bool IsDead;
	NavMeshAgent nav;

    void Start()
    {
        anim = GetComponent<Animator>();

        //Pour le player qui n'a pas de Nav #Thetoto
        try
        {
            nav = GetComponent<NavMeshAgent>();
        }
        catch { }
    }

    void Update()
    {
        if (IsSinking)
        {
            // c'est le machin qui fait fondre l'ennemi
            transform.Translate(-Vector3.up * sinkspeed * Time.deltaTime);
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
        anim.SetBool("Died", true); // Dont work #Thetoto
        StartSinking();
    }
    public void StartSinking()
    {
        if (nav)
        {
            nav.enabled = false;
        }
        GetComponent<Rigidbody>().isKinematic = true;
        try
        {
            GetComponent<SphereCollider>().enabled = false; // Pour empècher les autres animations... #Thetoto
        }
        catch { }

        IsSinking = true;
        Destroy(gameObject, 2f);
    }
}
