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
        if (isAttack && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            isAttack = false;
            coll.enabled = false;
        }
        if (Input.GetMouseButtonDown(0) && !isAttack)
        {
            isAttack = true;
            coll.enabled = true;
            anim.SetTrigger("Atk");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log(other.name);
        if (other.tag == "Shootable" && isAttack)
        {
            health = other.gameObject.GetComponent<Health>();
            Debug.Log(health.health + " before");
            health.TakeDamage(20);
            Debug.Log(health.health + " after");
            //coll.enabled = false;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }
}
