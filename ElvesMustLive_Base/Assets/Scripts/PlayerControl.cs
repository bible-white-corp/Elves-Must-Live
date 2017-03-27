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
    public GameObject UIRoot;

    public bool BuildConfirm;

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
            UIRoot = GameObject.Find("UI Root/Window Panel");
            GameObject.Find("UI Root/Window Panel/Scroll View/UIGrid").GetComponent<OnClickTurret>().home = this;
            UIRoot.SetActive(false);
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
            AvailableTurrets.Add("CrossBow");
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

		if (Input.GetButtonDown("Build") && !useController || (Input.GetButtonDown("2-Build") && useController))
        {
			if (BuildConfirm) 
			{
                if (raycast.Confirm())
                {
                    UIRoot.SetActive(false);
                    BuildConfirm = false;
                }
				
			} 
			else 
			{
                UIRoot.SetActive(true);
				raycast.SetObjPropect (pretourelle);
				raycast.SetObj (tourelle);
				BuildConfirm = true;
			}
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && !useController || (Input.GetAxis("2-Mouse ScrollWheel") > 0 && useController))
        {
			if (BuildConfirm) 
			{
				curretTurret = curretTurret - 1;
				if (curretTurret < 0) 
				{
					curretTurret = AvailableTurrets.Count - 1;
				}
                ChangeTurret(AvailableTurrets[curretTurret]);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && !useController || (Input.GetAxis("2-Mouse ScrollWheel") < 0 && useController))
        {
			if (BuildConfirm) 
			{
				curretTurret = curretTurret + 1;
				if (curretTurret >= AvailableTurrets.Count) 
				{
					curretTurret = 0;
				}
                ChangeTurret(AvailableTurrets[curretTurret]);
			}
        }
        
        if (Input.GetAxis("Rotate") < 0 && !useController || (Input.GetAxis("2-Rotate") < 0 && useController))
        {
            if (BuildConfirm)
            {
                raycast.LeftRotate();
            }
        }
		if (Input.GetAxis("Rotate") > 0 && !useController || (Input.GetAxis("2-Rotate") > 0 && useController)) 
		{
			if (BuildConfirm) 
			{
				raycast.RightRotate ();
			}
		}
		if (Input.GetKey (KeyCode.Escape)) 
		{
			raycast.Cancel();
            UIRoot.SetActive(false);
			BuildConfirm = false;
		}

        if (!useController && Input.GetButton("CenterCam") || useController && Input.GetButton("2-CenterCam")) //CenterCam = x
                                          //La touche L dans TLoZelda. Pas trouver d'autre examples #Thetoto.
        {
            camscript.LookPlayer(player.transform.rotation.eulerAngles.y, 15f);

        }
    }

    public void ChangeTurret(string name)
    {
        raycast.Cancel();
        tourelle = (GameObject)Resources.Load(name);
        pretourelle = (GameObject)Resources.Load(name + "Preview");
        raycast.SetObjPropect(pretourelle);
        raycast.SetObj(tourelle);
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
