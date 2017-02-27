using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBow : Photon.MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public float rx;
    public float ry;
    public float rz;
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
    //GameObject tpscam;
    GameObject fpscam;

    float t;
    float timeout = 0.8f;  

    // Use this for initialization
    void Start ()
    {
        home = GetComponentInParent<PlayerControl>();
        //tpscam = home.cam;
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
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("Cancel");
                Destroy(temparrow);
                isAttack = false;
                home.camscript.transform.eulerAngles = new Vector3(0f, home.camscript.m_LookAngle, 0f);
                // SET TPS
                fpscam.SetActive(false);
                home.player.transform.eulerAngles = new Vector3(0f, home.player.transform.eulerAngles.y, 0f);
            }

            if (t < timeout) //Respawn temp arrow after x seconds (and dont allow to fire a second time immediatly)
            {
                t += Time.deltaTime;
                if (t >= timeout)
                {
                    temparrow = (GameObject)Instantiate(Resources.Load("TempArrow"), transform);
                }
                return;
            }
            
            if (Input.GetButtonDown("Fire2"))
            {
                Destroy(temparrow);
                anim.SetTrigger("Arrow");

                arrow = PhotonNetwork.Instantiate("Arrow", fpscam.transform.position, Quaternion.Euler(fpscam.transform.rotation.eulerAngles),0);
                //arrow.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
                arrow.GetComponent<Rigidbody>().velocity = fpscam.transform.forward * 40;
                t = 0f;
            }   



        }
        else
        {

            if (Input.GetButtonDown("Fire1"))
            {
                isAttack = true;
                anim.SetTrigger("Atk");

                // Mettre la caméra (Une autre caméra) en mode "viser"
                // SET FPS
                fpscam.SetActive(true);
            }


        }
    }
}
