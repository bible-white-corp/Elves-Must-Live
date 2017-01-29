using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBow : MonoBehaviour {

    public int AttackDamage = 10;
    Health health;
    Animator anim;
    Collider coll;
    public bool isAttack;
    GameObject arrow;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponentInParent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Clic droit");
        }

        if (isAttack && !anim.GetCurrentAnimatorStateInfo(0).IsTag("atk"))
        {
            isAttack = false;
            //Lancer la flèche ici
        }
        if (Input.GetMouseButtonDown(0) && !isAttack)
        {
            isAttack = true;
            anim.SetTrigger("Atk");
            //Summon la flèche ici, pauser l'animation pour viser ?
            arrow = (GameObject)Instantiate(Resources.Load("Arrow"), transform);
            Debug.Log("Fleche");
            // Mettre la caméra (Une autre caméra) en mode "viser"
        }


    }
}
