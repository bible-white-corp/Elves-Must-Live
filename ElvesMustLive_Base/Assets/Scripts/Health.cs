using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson; //ici

public class Health : MonoBehaviour 
{
	public int health = 30;
	Animator anim;
	public float sinkspeed = 1f;
	bool IsSinking;
	bool IsDead;
	NavMeshAgent nav;
	Rigidbody body;
	float TimerbeforeDeath;
	ThirdPersonCharacter script;
	ThirdPersonUserControl script2;

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
		anim.SetTrigger ("Died"); // Dont work #Thetoto
        StartSinking();
    }
    public void StartSinking()
    {
        if (nav)
        {
			Destroy (nav);
			Debug.Log ("DEnav");
        }
        try
        {
            GetComponent<SphereCollider>().enabled = false; // Pour empècher les autres animations... #Thetoto
        }
        catch { }
		body = GetComponent<Rigidbody> ();
		if (gameObject.tag == "Player")
		{
			script = GetComponent<ThirdPersonCharacter> (); // le bail, c'est que utiliser ces scripts, il faut definir 
			script2 = GetComponent<ThirdPersonUserControl> (); // en using les scripts, regarde en haut
			Destroy (script);
			DestroyImmediate (script2);
		}
		Destroy (body);
        IsSinking = true;
        Destroy(gameObject, 3f);
    }
}
