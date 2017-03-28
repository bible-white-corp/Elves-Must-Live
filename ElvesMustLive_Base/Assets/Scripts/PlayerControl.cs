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

    public GameObject UIRoot;

    private UILabel UIGold;
    private UISlider UIHealth;

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
            //Connect UI To the player
            UIRoot = GameObject.Find("UI Root/Window Panel");
            GameObject.Find("UI Root/Window Panel/Scroll View/UIGrid").GetComponent<OnClickTurret>().home = this;
            UIRoot.SetActive(false); //Hide turret selection
            UIGold = GameObject.Find("UI Root/Gold").GetComponent<UILabel>();
            UIHealth = GameObject.Find("UI Root/Health").GetComponent<UISlider>();

            // Ce sera la seule dans le scene. On affiche pas ceux des autres joueurs.
            cam = (GameObject)Instantiate(Resources.Load("CameraRig"), transform.position, Quaternion.identity);
            camscript = cam.GetComponent<FreeLookCam>();
            camscript.m_Target = gameObject.transform; //Follow me
            camscript.home = this;
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
                cam.GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
            }
            else
            {
                cam.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0f, 1f, 1f);
                cam.GetComponentInChildren<AudioListener>().enabled = false;
                useController = true;
                screen = 2;
            }
        }
        else
        {
            screen = 0;
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

        if (!useController && Input.GetButton("CenterCam") || useController && Input.GetButton("2-CenterCam")) //CenterCam = x
                                                                                                               //La touche L dans TLoZelda. Pas trouver d'autre examples #Thetoto.
        {
            camscript.LookPlayer(player.transform.rotation.eulerAngles.y, 15f);

        }
    }

    private void OnGUI()
    {
        UIHealth.value = hp.health / hp.maxhealth;
        UIGold.text = gold + " Golds";
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
