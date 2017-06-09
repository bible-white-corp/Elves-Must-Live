using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

public class PlayerHealth : MonoBehaviour {
    public float health = 30;
    public float maxhealth = 30;
    //public GameObject Slider;
    //private Slider healthSlider;
	public float sinkspeed = 10f;
    Animator anim;
    public bool IsDead;
    Rigidbody body;
	float TimerbeforeDeath;
    bool IsSinking;
    bool IsRespawning;

	AudioClip gothit;
	AudioClip jump;
	AudioClip death;
	AudioSource audioS;
	float timebeforehit;
	bool beinghitted;


    PlayerControl home;


    public Renderer MainRenderer;
    // Use this for initialization
    void Start ()
	{
		beinghitted = false;
		gothit = (AudioClip)Resources.Load("Sound/Player/coup_ventre");
		death = (AudioClip)Resources.Load("Sound/Player/death");
		audioS = GetComponent<AudioSource> ();
        home = GetComponentInParent<PlayerControl>();
        //healthSlider = Slider.GetComponent<Slider>();
        anim = home.anim;
		TimerbeforeDeath = 0;
		timebeforehit = 0;

    }
   

    // Update is called once per frame
    void Update () 
	{
        if (Input.GetKeyDown(KeyCode.H))
        {
            health = maxhealth;
        }
		if (beinghitted) 
		{
			timebeforehit += Time.deltaTime;
			if (timebeforehit > 0.4) 
			{
				beinghitted = false;
				timebeforehit = 0;
			}
		}


        /*if (hitStatus)
        {
            time += Time.deltaTime;
            if (time > hitTime)
            {
                hitStatus = false;
                GetComponent<Renderer>().material.color = backColor;
                time = 0f;
            }
        }*/
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
            if (TimerbeforeDeath > 4f)
            {
                IsSinking = false;
                TimerbeforeDeath = 0f;
                FINISH();
            }
		}
        if (IsRespawning)
        {
            TimerbeforeDeath += Time.deltaTime;
            if (TimerbeforeDeath > 2.5f)
            {
                IsRespawning = false;
                TimerbeforeDeath = 0f;
                GetComponent<Rigidbody>().isKinematic = false;
                home.camscript.m_Target = gameObject.transform;
                home.transform.position = home.game.transform.position;

            }
        }
	}

    public void TakeDamage(int amount)
    {

		if (IsDead) 
		{
			return;
		} 
		else if (!beinghitted)
		{
			audioS.PlayOneShot(gothit);
			beinghitted = true;
		}
        health -= amount;
        //healthSlider.value = health;

        //MainRenderer.material.color = Color.red;

        if (health <= 0)
        {
            Death();
        }
        

    }

    public void Death()
    {

		IsSinking = true;
        IsDead = true;
        anim.SetTrigger("Died");
        GetComponent<Rigidbody>().isKinematic = true;
		Destroy (GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ());
		Destroy (GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>());
		audioS.PlayOneShot (death);
        try
        {
            home.camscript.m_Target = null;
        }
        catch
        {}
        //Destroy(gameObject, 4f);
    }

    private void FINISH()
    {
        home.MyUI.DeadMode();
        
    }

    public void Respawn()
    {
        IsDead = false;
        anim.SetBool("Died", false);
        anim.SetTrigger("Respawn");
		gameObject.AddComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ();
		gameObject.AddComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ();

        health = maxhealth;
        IsRespawning = true;
    }
}
