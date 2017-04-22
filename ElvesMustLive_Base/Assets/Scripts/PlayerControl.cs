using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class PlayerControl : Photon.MonoBehaviour {

    public GameObject player;
    public GameObject cam;
    public GameObject fpscam;
    public CapsuleCollider capscoll;
    public Animator anim;
    public PlayerHealth hp;
    public int gold;
    public PhotonView view;
    public bool isMine;
    public List<GameObject> weapon;
    public TextMesh txtname;
    public RayCast raycast;
    public bool useController = false;

    public Game game;

    public UIControl MyUI;

    [HideInInspector]
    public FreeLookCam camscript;


    public int screen; // 0 = full, 1 = left, 2 = right

    // Use this for initialization
    void Awake () 
	{   
        isMine = photonView.isMine;
        view = photonView;
        if (isMine)
        {
            cam = (GameObject)Instantiate(Resources.Load("CameraRig"), transform.position, Quaternion.identity);
            camscript = cam.GetComponent<FreeLookCam>();
            camscript.m_Target = gameObject.transform; //Follow me
            camscript.home = this;

            game = GameObject.Find("GameManager").GetComponent<Game>();
        }
        else
        {
            txtname.text = photonView.owner.NickName;
        }

        if (PlayerPrefs.GetInt("mod") == 1) //mod == 1 : splitted screen
        { 
            if (int.Parse(photonView.instantiationData[0].ToString()) == 0)
            {
                screen = 1;
                MyUI = UIControl.SetUI("Left", this);
                cam.GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
            }
            else
            {
                MyUI = UIControl.SetUI("Right", this);
                cam.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0f, 1f, 1f);
                cam.GetComponentInChildren<AudioListener>().enabled = false; // Only one Audio listener...
                useController = true;
                screen = 2;
            }
        }
        else
        {
            screen = 0;
            MyUI = UIControl.SetUI("SinglePlayer", this);
        }

    }
	
	// Update is called once per frame
	void Update () 
	{
        if (isMine == false && PhotonNetwork.connected == true)
        {
            return;
        }

        if (Input.GetKey("g"))
        {
            gold += 10;
        }

        if (Input.GetKeyDown("t"))
        {
            MyUI.tchat.SetActive(!MyUI.tchat.activeSelf);
        }

        if (!useController && Input.GetButton("CenterCam") || useController && Input.GetButton("2-CenterCam")) //CenterCam = x
                                                                                                               //La touche L dans TLoZelda. Pas trouver d'autre examples #Thetoto.
        {
            camscript.LookPlayer(player.transform.rotation.eulerAngles.y, 15f);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            raycast.AddTurret("Cristal");
            raycast.AddTurret("CrossBow");
            raycast.AddTurret("Hammer");
            raycast.AddTurret("Projector");
        }
    }


    #region PUN RPC

    [PunRPC]
    public void ActiveW(int i)
    {
        weapon[i].SetActive(true);
    }
    [PunRPC]
    public void DesactiveW(int i)
    {
        weapon[i].SetActive(false);
    }
    [PunRPC]
    public void PlaceTurret(string name, Vector3 pos, Quaternion rot)
    {
        PhotonNetwork.InstantiateSceneObject(name, pos, rot, 0, new object[] { });

    }
    #endregion
}
