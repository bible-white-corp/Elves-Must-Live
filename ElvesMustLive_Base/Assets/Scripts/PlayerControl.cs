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
	public GameObject tourelle;
	public GameObject pretourelle;
	bool BuildConfirm;

    PlayerControl home;

    // Use this for initialization
    void Awake () 
	{
		BuildConfirm = false;
        isMine = photonView.isMine;
        view = photonView;
        if (isMine)
        {
            // Set in the Editor.
            // Ce sera la seule dans le scene. On affiche pas ceux des autres joueurs.
            cam = GameObject.FindGameObjectWithTag("PlayerCamera");
            camscript = cam.GetComponent<FreeLookCam>();
            camscript.m_Target = gameObject.transform;
            
        }
        else
        {
            txtname.text = photonView.owner.NickName;
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
		if (Input.GetKey ("q")) 
		{
			if (BuildConfirm) 
			{
				raycast.LeftRotate ();
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

        if (Input.GetButton("CenterCam")) //CenterCam = x
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
    public void Tets()
    {
        Debug.Log("Test");
    }

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
    #endregion
}
