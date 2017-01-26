using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public int AttackDamage = 10;
    Health health;
    Animator anim;
    Collider coll;

    // Use this for initialization
    void Start () {
        anim = GetComponentInParent<Animator>();
        coll = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            coll.enabled = true;
            coll.isTrigger = true;
            anim.SetTrigger("Atk");
        }
        if (Input.GetMouseButtonUp(0))
        {
            coll.isTrigger = false;
            coll.enabled = false;
            
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Shootable")
        {
            health = other.gameObject.GetComponent<Health>();
            Debug.Log(health.health  + " before");
            health.TakeDamage(20);
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
