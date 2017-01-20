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

        //Pour le player qui n'a pas de Nav
        try
        {
            nav = GetComponent<NavMeshAgent>();
        }
        catch (System.Exception)
        {
            Debug.Log("No NavMesh");
        }
            
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
        anim.SetBool("Died", true);
        StartSinking();
    }
    public void StartSinking()
    {
        if (nav)
        {
            nav.enabled = false;
        }
        GetComponent<Rigidbody>().isKinematic = true;
        Destroy(GetComponent<SphereCollider>()); // Pour empècher les autres animations...
        IsSinking = true;
        Destroy(gameObject, 2f);
    }
}
