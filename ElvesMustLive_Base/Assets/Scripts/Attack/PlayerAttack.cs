using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Photon.MonoBehaviour
{

    public int AttackDamage = 10;
    Health health;
    Animator anim;
    Collider coll;
    public bool isAttack;

    PlayerControl home;

    // Use this for initialization
    void Start () {
        home = GetComponentInParent<PlayerControl>();
        anim = home.anim;
        coll = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (home.isMine == false && PhotonNetwork.connected == true || home.game.paused)
        {
            return;
        }

        if (isAttack && !anim.GetCurrentAnimatorStateInfo(0).IsTag("atk"))
        {
            isAttack = false;
            coll.enabled = false;
        }
        if ((Input.GetButtonDown("Fire1") && !home.useController || (Input.GetButtonDown("2-Fire1") && home.useController)) && !isAttack && !home.raycast.BuildConfirm)
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
            health.TakeDamage(AttackDamage, home);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }
}
