using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : Photon.MonoBehaviour 
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
    public int reward = 10; //Gold when a player kill.
    bool earned = false;
	public int Armor = 0;

    public AudioSource audio;

    void Start()
    {
        obj = gameObject;
        anim = GetComponent<Animator>();
        //Si pas de nav, pour certains ennemies immobiles.
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

    // A terme, j'aimerai que ce soit par RPC, pour synchro correctement entre les clients.
    // La personne qui fait des dégats avec son arme envoie aux autres et pas chacun de son coté #Thetoto
    [PunRPC]
    void SendDamage(int amount, int dest)
    {
        if (PhotonView.Get(gameObject) != photonView)
        {
            return;
        }
        if (IsDead)
        {
            return;
        }
		health -= amount - Armor;
        AudioClip hitClip = (AudioClip)Resources.Load("Sound/Orc/hit");
        audio.PlayOneShot(hitClip);
		Debug.Log (health);
        if (health <= 0)
        {
			Debug.Log ("Death called");
            Death();
        }
    }

    public void TakeDamage(int amount)
    {
        photonView.RPC("SendDamage", PhotonTargets.AllBufferedViaServer, amount, photonView.viewID);
		Debug.Log ("RPC CALLED");
    }
    public void TakeDamage(int amount, PlayerControl from)
    {
        photonView.RPC("SendDamage", PhotonTargets.AllBufferedViaServer, amount, photonView.viewID);
        if (health - amount <= 0 && !earned)
        {
            from.gold += reward;
            earned = true;
        }
    }
    public void Death()
    {
        audio.Stop();
        AudioClip deathClip = (AudioClip)Resources.Load("Sound/Orc/death");
        audio.PlayOneShot(deathClip);
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
