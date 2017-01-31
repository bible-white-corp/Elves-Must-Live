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
    GameObject realarrow;

    Game game;
    GameObject tpscam;
    GameObject fpscam;


    // Use this for initialization
    void Start ()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
        tpscam = game.cam;
        fpscam = game.fpscam;
        Debug.Log(fpscam);
        fpscam.SetActive(false);
        anim = GetComponentInParent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isAttack && anim.GetCurrentAnimatorStateInfo(0).IsName("Bow2"))
        {
            Debug.Log("Destroy temp arrow");
            Destroy(arrow);
            isAttack = false;
            tpscam.SetActive(true);
            fpscam.SetActive(false);
            game.player1.transform.rotation = Quaternion.Euler(0, game.player1.transform.rotation.y, 0);
        }

        if (isAttack && anim.GetCurrentAnimatorStateInfo(0).IsName("Wait"))
        {
            Debug.Log("Waiting");
            
            if (Input.GetButton("Fire2"))
            {
                anim.SetTrigger("Arrow");
            }

            if (Input.GetButton("Fire1"))
            {
                anim.SetTrigger("Cancel");
            }
        }

        if (Input.GetButton("Fire1") && !isAttack)
        {
            isAttack = true;
            anim.SetTrigger("Atk");
            //Summon la flèche ici, pauser l'animation pour viser ?
            arrow = (GameObject)Instantiate(Resources.Load("Arrow"), transform);
            Debug.Log("Fleche");
            // Mettre la caméra (Une autre caméra) en mode "viser"
            tpscam.SetActive(false);
            fpscam.SetActive(true);
        }


    }
}
