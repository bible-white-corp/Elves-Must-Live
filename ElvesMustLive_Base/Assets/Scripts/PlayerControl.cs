using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class PlayerControl : Photon.MonoBehaviour {

    public GameObject player;
    public GameObject cam;
    public GameObject fpscam;
    public FreeLookCam camscript;
    public Animator anim;
    public PlayerHealth hp;
    public CapsuleCollider capscoll;
    public bool isMine;

    PlayerControl home;

	// Use this for initialization
	void Awake () {
        isMine = photonView.isMine;
        if (isMine)
        {
            // Set in the Editor.
            // Ce sera la seule dans le scene. On affiche pas ceux des autres joueurs.
            cam = GameObject.FindGameObjectWithTag("PlayerCamera");
            camscript = cam.GetComponent<FreeLookCam>();
            camscript.m_Target = gameObject.transform;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if (isMine == false && PhotonNetwork.connected == true)
        {
            return;
        }

        if (Input.GetButton("CenterCam")) //CenterCam = x
                                          //La touche L dans TLoZelda. Pas trouver d'autre examples #Thetoto.
        {
            camscript.LookPlayer(player.transform.rotation.eulerAngles.y, 15f);

        }
    }
}
