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
	Mov mov1;
    public Health hp;
	float Distance;
	NavMeshAgent nav;
    BoxCollider coll;
	public float FightDistance;

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

			if (Distance <= (FightDistance-0.1) && nav.enabled) // Pour s'arreter d'avancer un tout petit peu après sinon bug #Thetoto
            {
                nav.enabled = false;
                anim.SetBool("InMov", false);
            }

			if (Distance <= FightDistance)// Quand on est a 1.6, on commence a atk # Thetoto
            {
                //hp.gameObject.transform.LookAt(mov1.player.transform);  // Regarder le player pour pas qu'il parte en couille   
                anim.SetBool("Engage", true);
                coll.enabled = true;
                RotateTarget();
            }

			if (Distance > FightDistance && !nav.enabled) // On s'est trop eloigne, plus a porte #Thetoto
            {
                nav.enabled = true;
                coll.enabled = false;
                anim.SetBool("InMov", true);
                anim.SetBool("Engage", false);
            }
        }
    }
    
    public void RotateTarget()
    {
        Transform target = playerhp.transform;
        Vector3 targetDir = target.position - hp.transform.position;
        float step = 3 * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(hp.transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(hp.GetComponent<Transform>().position, newDir, Color.red);
        hp.transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hp.IsDead)
        {
            playerhp.TakeDamage(AttackDamage);
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }
}
