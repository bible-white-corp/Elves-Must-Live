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
    public PhotonView view;
    public bool isMine;
    public List<GameObject> weapon;
    public TextMesh txtname;
    public RayCast raycast;
    public bool useController = false;

    bool BuildConfirm;
    GameObject tourelle;
    GameObject pretourelle;
    List<string> AvailableTurrets;
    int curretTurret = 0;

    public int screen; // 0 = full, 1 = left, 2 = right

    // Use this for initialization
    void Awake () 
	{   
        isMine = photonView.isMine;
        view = photonView;

        if (isMine)
        {
            // Set in the Editor.
            // Ce sera la seule dans le scene. On affiche pas ceux des autres joueurs.
            cam = (GameObject)Instantiate(Resources.Load("CameraRig"), transform.position, Quaternion.identity);
            camscript = cam.GetComponent<FreeLookCam>();
            camscript.m_Target = gameObject.transform;
            camscript.home = this;

            BuildConfirm = false;
            AvailableTurrets = new List<string>();
            AvailableTurrets.Add("Cannon");
            AvailableTurrets.Add("Hammer");
            AvailableTurrets.Add("Crossbow");
            tourelle = (GameObject)Resources.Load(AvailableTurrets[curretTurret]);
            pretourelle = (GameObject)Resources.Load(AvailableTurrets[curretTurret] + "Preview");
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
                hp.pos.x += Screen.width / 2;
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

		if (Input.GetKeyDown("b"))
        {
			if (BuildConfirm) 
			{
				raycast.Confirm ();
				BuildConfirm = false;
			} 
			else 
			{
				raycast.SetObjPropect (pretourelle);
				raycast.SetObj (tourelle);
				BuildConfirm = true;
			}
        }
        if (Input.GetKeyDown("r"))
        {
			if (BuildConfirm) 
			{
				curretTurret = curretTurret - 1;
				if (curretTurret < 0) 
				{
					curretTurret = AvailableTurrets.Count - 1;
				}
				raycast.Cancel ();
				tourelle = (GameObject)Resources.Load (AvailableTurrets [curretTurret]);
				pretourelle = (GameObject)Resources.Load (AvailableTurrets [curretTurret] + "Preview");
				raycast.SetObjPropect (pretourelle);
				raycast.SetObj (tourelle);
			}
        }

        if (Input.GetKeyDown("t"))
        {
			if (BuildConfirm) 
			{
				curretTurret = curretTurret + 1;
				if (curretTurret >= AvailableTurrets.Count) 
				{
					curretTurret = 0;
				}
				raycast.Cancel ();
				tourelle = (GameObject)Resources.Load (AvailableTurrets [curretTurret]);
				pretourelle = (GameObject)Resources.Load (AvailableTurrets [curretTurret] + "Preview");
				raycast.SetObjPropect (pretourelle);
				raycast.SetObj (tourelle);
			}
        }
        if (Input.GetKey("q"))
        {
            if (BuildConfirm)
            {
                raycast.LeftRotate();
            }
        }
		if (Input.GetKey ("e")) 
		{
			if (BuildConfirm) 
			{
				raycast.RightRotate ();
			}
		}
		if (Input.GetKey (KeyCode.Escape)) 
		{
			raycast.Cancel();
			BuildConfirm = false;
		}

        if (!useController && Input.GetButton("CenterCam") || useController && Input.GetButton("2-CenterCam")) //CenterCam = x
                                          //La touche L dans TLoZelda. Pas trouver d'autre examples #Thetoto.
        {
            camscript.LookPlayer(player.transform.rotation.eulerAngles.y, 15f);

        }
    }
	public void TurretBuildFailed()
	{
		this.BuildConfirm = true;
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
