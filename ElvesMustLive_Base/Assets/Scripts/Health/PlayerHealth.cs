using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class PlayerHealth : MonoBehaviour {
    public int health = 30;
	public float sinkspeed = 10f;
    Animator anim;
    public bool IsDead;
    Rigidbody body;
	float TimerbeforeDeath;
	bool IsSinking;
	GameObject MyCam;

    PlayerControl home;


    // Use this for initialization
    void Start ()
	{
        home = GetComponentInParent<PlayerControl>();
        anim = home.anim;
		TimerbeforeDeath = 0;
        MyCam = home.cam;
    }
	
	// Update is called once per frame
	void Update () 
	{
		
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
        home.camscript.m_Target = null;
		IsSinking = true;
        IsDead = true;
        anim.SetTrigger("Died");
        GetComponent<Rigidbody>().isKinematic = true;
        // A faire qu'une fois donc demande pas tant de ressources...
        Destroy(GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>());
        Destroy(GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>());
        
        Destroy(gameObject, 4f);
    }
        
}
