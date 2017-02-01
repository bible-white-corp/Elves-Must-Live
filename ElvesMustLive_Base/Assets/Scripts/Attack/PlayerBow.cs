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

    float saveY;

    // Use this for initialization
    void Start ()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
        tpscam = game.cam;
        fpscam = game.fpscam;
        anim = GetComponentInParent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isAttack && anim.GetCurrentAnimatorStateInfo(0).IsName("Bow2"))
        {
            isAttack = false;

            Debug.Log(game.player1.transform.rotation.y);
            //game.player1.transform.rotation = Quaternion.Euler(0, saveY, 0);
            Debug.Log(game.player1.transform.rotation.y);
            // SET TPS
            fpscam.SetActive(false);
            //tpscam.transform.rotation = Quaternion.Euler(game.player1.transform.rotation.x, game.player1.transform.rotation.y, game.player1.transform.rotation.z);
        }

        if (isAttack && anim.GetCurrentAnimatorStateInfo(0).IsName("Wait"))
        {
            Debug.Log("Waiting");
            saveY = game.player1.transform.rotation.y;
            if (Input.GetButton("Fire2"))
            {
                Debug.Log("Destroy temp arrow");
                Destroy(arrow);
                anim.SetTrigger("Arrow");

                Debug.Log(saveY);
                arrow = (GameObject)Instantiate(Resources.Load("Arrow"), transform.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w));

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
            arrow.GetComponent<Rigidbody>().isKinematic = true;

            // Mettre la caméra (Une autre caméra) en mode "viser"
            // SET FPS
            fpscam.SetActive(true);
        }


    }
}
