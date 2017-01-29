using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyAttack : MonoBehaviour
{
	public int AttackDamage = 10;
	Animator anim;
    public PlayerHealth playerhp;
    float timer;
	EnnemyMov1 mov1;
    public Health hp;
	float Distance;
	NavMeshAgent nav;
    BoxCollider coll;

	void Start () // Pas d'info sur le joueur ici, car si il change, (respawn) marche plus. 
	{
        mov1 = GetComponentInParent<EnnemyMov1>();
        hp = GetComponentInParent<Health>();
        coll = GetComponent<BoxCollider>();
        anim = mov1.animator;
        nav = mov1.nav;
	}

    void Update()
    {
        if (!hp.IsDead)
        {
            // Ceci est actif que quand trigger de mov1 actif.
            Distance = mov1.distance;

            if (Distance <= 1.5f && nav.enabled) // Pour s'arreter d'avancer un tout petit peu après sinon bug #Thetoto
            {
                nav.enabled = false;
                anim.SetBool("InMov", false);
            }

            if (Distance <= 1.6f)// Quand on est a 1.6, on commence a atk # Thetoto
            {
                hp.gameObject.transform.LookAt(mov1.player.transform);  // Regarder le player pour pas qu'il parte en couille   
                anim.SetBool("Engage", true);
                coll.enabled = true;
            }

            if (Distance > 1.6f) // On s'est trop eloigne, plus a porte #Thetoto
            {
                nav.enabled = true;
                coll.enabled = false;
                anim.SetBool("InMov", true);
                anim.SetBool("Engage", false);
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerhp.TakeDamage(AttackDamage);
            Debug.Log("Player :" + playerhp.health);
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }
}
