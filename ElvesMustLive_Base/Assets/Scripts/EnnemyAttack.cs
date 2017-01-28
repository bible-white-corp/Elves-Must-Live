using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyAttack : MonoBehaviour
{
	public float TimeBetweenAttacks = 1.6f;
	public int AttackDamage = 10;
	Animator anim;
    public PlayerHealth playerhp;
    float timer;
	EnnemyMov1 mov1;
	float Distance;
	NavMeshAgent nav;

	void Start () // Pas d'info sur le joueur ici, car si il change, (respawn) marche plus. 
	{
        mov1 = GetComponentInChildren<EnnemyMov1>();
        anim = mov1.animator;
        nav = mov1.nav;
	}

	void Update () 
	{
        // Ceci est actif que quand trigger de mov1 actif.
        Distance = mov1.distance;
		timer += Time.deltaTime;

        if (Distance <= 1.5f && nav.enabled) // Pour s'arreter d'avancer un tout petit peu après sinon bug #Thetoto
        {
            nav.enabled = false;
            anim.SetBool("InMov", false);
        }

        if (Distance <= 1.6f)// Quand on est a 1.6, on commence a atk # Thetoto
        {
            anim.SetBool("Engage", true); 
            timer += Time.deltaTime;
            if (timer >= TimeBetweenAttacks)
            {
                timer = 0f;
                gameObject.transform.LookAt(mov1.player.transform); // Regarder le player pour pas qu'il parte en couille   
                playerhp.TakeDamage(AttackDamage);
            }
        }

        if (Distance > 1.6f) // On s'est trop eloigne, plus a porte #Thetoto
        {
            nav.enabled = true;
            anim.SetBool("InMov", true);
            anim.SetBool("Engage", false);

        }
	}
}
