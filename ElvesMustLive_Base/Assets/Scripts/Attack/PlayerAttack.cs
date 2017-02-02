using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public int AttackDamage = 10;
    Health health;
    Animator anim;
    Collider coll;
    public bool isAttack;

    // Use this for initialization
    void Start () {
        anim = GetComponentInParent<Animator>();
        coll = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isAttack && !anim.GetCurrentAnimatorStateInfo(0).IsTag("atk"))
        {
            isAttack = false;
            coll.enabled = false;
        }
        if (Input.GetButton("Fire1") && !isAttack)
        {
            isAttack = true;
            coll.enabled = true;
            anim.SetTrigger("Atk");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Shootable" && isAttack) // Can attack twice a same Ennemy...
        {
            health = other.gameObject.GetComponent<Health>();
            health.TakeDamage(AttackDamage);
            Debug.Log(health.health + " after");
        }
        
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }
}
