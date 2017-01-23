using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class PlayerHealth : MonoBehaviour {
    public int health = 30;
	public float sinkspeed = 10f;
    Animator anim;
    bool IsDead;
    Rigidbody body;
    CapsuleCollider caps;
	float TimerbeforeDeath;
	bool IsSinking;
	FreeLookCam camscript;
	GameObject Cam;


    // Use this for initialization
    void Start ()
	{
        anim = GetComponent<Animator>();
		TimerbeforeDeath = 0;
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
		Cam = GameObject.FindGameObjectWithTag ("PlayerCamera");
		Debug.Log (Cam.name);
		camscript = Cam.GetComponent<FreeLookCam> ();
		camscript.enabled = false;
		IsSinking = true;
        IsDead = true;
        anim.SetTrigger("Died");
        GetComponent<Rigidbody>().isKinematic = true;
        // Le joueur va pas mourir toutes les deux minutes, ca devrais pas poser de pb
        Destroy(GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>());
        Destroy(GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>());
        Destroy(gameObject, 4f);
    }
        
}
