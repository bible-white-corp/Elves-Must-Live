using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBow : MonoBehaviour {

    public int AttackDamage = 10;
    Health health;
    Animator anim;
    Collider coll;
    public bool isAttack;
    GameObject temparrow;
    GameObject arrow;

    PlayerControl home;
    //SET IN THE EDITOR
    public GameObject arrowspot;
    GameObject tpscam;
    GameObject fpscam;

    float saveY;

    // Use this for initialization
    void Start ()
    {
        home = GetComponentInParent<PlayerControl>();
        tpscam = home.cam;
        fpscam = home.fpscam;
        anim = home.anim;
    }

    // Update is called once per frame
    void Update()
    {
        if (home.isMine == false && PhotonNetwork.connected == true)
        {
            return;
        }

        if (isAttack)
        {
            //Respawn temp arrow after x seconds (and dont allow to fire a second time immediatly)
            if (Input.GetButtonDown("Fire2"))
            {
                Debug.Log("Destroy temp arrow");
                Destroy(temparrow);
                anim.SetTrigger("Arrow");

                arrow = (GameObject)Instantiate(Resources.Load("Arrow"), arrowspot.transform.position, arrowspot.transform.rotation);
                arrow.transform.position = arrowspot.transform.position + Camera.main.transform.forward;
                arrow.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 40;
                //arrow.transform.eulerAngles = new Vector3(-arrowspot.transform.eulerAngles.x, arrowspot.transform.eulerAngles.y - 90, arrowspot.transform.eulerAngles.z);

            }

            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("Cancel");
                isAttack = false;
                home.camscript.transform.eulerAngles = new Vector3(0f, home.camscript.m_LookAngle, 0f);
                // SET TPS
                fpscam.SetActive(false);
            }

        }
        else
        {

            if (Input.GetButtonDown("Fire1"))
            {
                isAttack = true;
                anim.SetTrigger("Atk");
                //Summon la flèche ici, pauser l'animation pour viser ?
                temparrow = (GameObject)Instantiate(Resources.Load("TempArrow"), transform);

                // Mettre la caméra (Une autre caméra) en mode "viser"
                // SET FPS
                fpscam.SetActive(true);
            }


        }
    }
}
