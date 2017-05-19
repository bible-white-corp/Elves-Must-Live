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
    public TextMesh txtname;
    public RayCast raycast;
    public bool useController = false;
    public Switch weapons;

    public Game game;

    public UIControl MyUI;

    public Camera mapCam;

    [HideInInspector]
    public FreeLookCam camscript;

    public bool MenuActif = false;
	public bool ChatActif = false;
	public bool BtkActif = false;
	public bool PauseActif = false;

    public int screen; // 0 = full, 1 = left, 2 = right

    // Use this for initialization
    void Awake () 
	{


        game = GameObject.Find("GameManager").GetComponent<Game>();

        if (PhotonNetwork.isMasterClient)
        {
            game.masterClient = this;
            game.InitWave();
        }

        isMine = photonView.isMine;
        view = photonView;
        if (isMine)
        {


            cam = (GameObject)Instantiate(Resources.Load("CameraRig"), transform.position, Quaternion.identity);
            camscript = cam.GetComponent<FreeLookCam>();
            camscript.m_LookAngle = game.transform.eulerAngles.y;
            camscript.m_Target = gameObject.transform; //Follow me
            camscript.home = this;




            if (PlayerPrefs.GetInt("mod") == 1) //mod == 1 : splitted screen
            {
                if (int.Parse(photonView.instantiationData[0].ToString()) == 0)
                {
                    screen = 1;
                    MyUI = UIControl.SetUI("Left", this);
                    cam.GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
                    if (PlayerPrefs.GetInt("Control") == 1)
                    {
                        useController = true;
                    }
                    else
                    {
                        useController = false;
                    }
                }
                else
                { 
                    MyUI = UIControl.SetUI("Right", this);
                    cam.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0f, 1f, 1f);
                    cam.GetComponentInChildren<AudioListener>().enabled = false; // Only one Audio listener...
                    if (PlayerPrefs.GetInt("Control") == 1)
                    {
                        useController = false;
                    }
                    else
                    {
                        useController = true;
                    }
                    screen = 2;
                }
            }
            else
            {
                screen = 0;
                MyUI = UIControl.SetUI("SinglePlayer", this);
            }
        }
        else
        {
            txtname.text = photonView.owner.NickName;
        }

    }
	
	// Update is called once per frame
	void Update () 
	{
        if (MenuActif)
        {
            //anim.SetBool("InMov", false);
        }

        if (isMine == false && PhotonNetwork.connected == true)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus)) //////// ZOOM MINIMAP
        {
            if (mapCam.orthographicSize > 50)
            {
                return;
            }
            mapCam.orthographicSize += 1;
        }
        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
        {
            if (mapCam.orthographicSize < 10)
            {
                return;
            }
            mapCam.orthographicSize -= 1;
        }

        if (Input.GetKey("g"))
        {
            gold += 10;
        }

        if (Input.GetKeyDown(KeyCode.Return) && !ChatActif && !MenuActif)
        {
			if (!game.wave.StartWave()&&!game.wave.wave)
            {
				//PhotonNetwork.LeaveRoom();
            }
            else
            {
                MyUI.Info.enabled = false;
            }
            //Afficher un texte "Press Enter pour lancer la prochaine vague."
        }

        if (((!useController && Input.GetKeyDown("v")) || (useController && Input.GetKeyDown(KeyCode.Joystick1Button7))) && !ChatActif && !MenuActif)
        {
            if (MyUI.boutikScript.gameObject.GetActive())
            {
                MyUI.boutikScript.gameObject.SetActive(false);
                MenuActif = false;
                BtkActif = false;
                if (useController)
                {
                    MyUI.mouseControl.Active(false);
                }
            }
            else
            {
                MyUI.boutikScript.gameObject.SetActive(true);
                MenuActif = true;
                BtkActif = true;
                if (useController)
                {
                    MyUI.mouseControl.Active(true);
                }
            }
        }

        if (Input.GetKeyDown("c") && !ChatActif && !MenuActif)
        {
            if (MyUI.boutikOrc.gameObject.GetActive())
            {
                MyUI.boutikOrc.gameObject.SetActive(false);
                MenuActif = false;
                BtkActif = false;
            }
            else
            {
                MyUI.boutikOrc.gameObject.SetActive(true);
                MenuActif = true;
                BtkActif = true;
            }
        }

        if ((!useController && Input.GetKeyDown ("escape")) || (useController && Input.GetKeyDown(KeyCode.Joystick1Button6)))
		{
            if (raycast.BuildConfirm)
            {
                return;
            }
			if (ChatActif) 
			{
				MyUI.tchat.SetActive (!MyUI.tchat.activeSelf);
				MyUI.tchat.GetComponentInChildren<UIInput> ().isSelected = true;
				ChatActif = false;
				MenuActif = false;
            }
            else if (MyUI.boutikOrc.gameObject.GetActive())
            {
                MyUI.boutikOrc.gameObject.SetActive(false);
                BtkActif = false;
                MenuActif = false;
                if (useController)
                {
                    MyUI.mouseControl.Active(false);
                }
            }
			else if (BtkActif) 
			{
                if (MyUI.upgrade.gameObject.GetActive())
                {
                    MyUI.upgrade.gameObject.SetActive(false);
                }
                else
                {
                    MyUI.boutikScript.gameObject.SetActive(false);
                    BtkActif = false;
                    MenuActif = false;
                    if (useController)
                    {
                        MyUI.mouseControl.Active(false);
                    }
                }
			}
            
            /*else if (MyUI.Info.enabled)
            {
                MyUI.Info.enabled = false;
            }*/
            else
			{
                if (MyUI.PauseWindow.GetActive() || MyUI.settrings.gameObject.GetActive())
                {
                    if (MyUI.settrings.gameObject.GetActive())
                    {
                        MyUI.PauseWindow.SetActive(true);
                        MyUI.settrings.gameObject.SetActive(false);
                    }
                    else
                    {
                        MyUI.PauseWindow.SetActive(false);
                        MenuActif = false;
                        PauseActif = false;
                        if (useController)
                        {
                            MyUI.mouseControl.Active(false);
                        }
                    }
                }
                else
                {
                    MyUI.PauseWindow.SetActive(true);
                    MenuActif = true;
                    PauseActif = true;
                    if (useController)
                    {
                        MyUI.mouseControl.Active(true);
                    }
                }
			}
		}

		if (Input.GetKeyDown("t") && !MenuActif)
        {
			if (!ChatActif)
			{
            MyUI.tchat.SetActive(!MyUI.tchat.activeSelf);
				ChatActif = true;
				MenuActif = true;
			}
        }

        if (!useController && Input.GetButton("CenterCam") || useController && Input.GetButton("2-CenterCam")) //CenterCam = x
                                                                                                               //La touche L dans TLoZelda. Pas trouver d'autre examples #Thetoto.
        {
            camscript.LookPlayer(player.transform.rotation.eulerAngles.y, 15f);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            raycast.AddTurret("Cristal",2);
            raycast.AddTurret("CrossBow",2);
            raycast.AddTurret("Hammer",2);
            raycast.AddTurret("Projector",2);
            raycast.AddTurret("Rocket",1);
        }
    }


    #region PUN RPC

    [PunRPC]
    public void ActiveW(int i)
    {
        anim.SetBool(weapons.weapon[i].tag, true);
        weapons.weapon[i].SetActive(true);
    }
    [PunRPC]
    public void DesactiveW(int i)
    {
        anim.SetBool(weapons.weapon[i].tag, false);
        weapons.weapon[i].SetActive(false);
    }
    [PunRPC]
    public void ShowHistory(string key)
    {
        MyUI.SetStory(key);
    }
    [PunRPC]
    public void PlaceTurret(string name, Vector3 pos, Quaternion rot, int propri)
    {
        PhotonNetwork.InstantiateSceneObject(name, pos, rot, 0, new object[1] { propri });
    }
    #endregion
}
