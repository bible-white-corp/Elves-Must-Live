using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class FPSCam : MonoBehaviour {

    PlayerControl home;

    FreeLookCam tpscam;

    GameObject target;
    Vector3 temp;

    public bool viseur = true;           // SET THE VISEUR
    public int sizeviseur = 20;           // SET THE VISEUR
    float adapt;

    private GUIStyle guistyle;

    private void Start()
    {
        home = GetComponentInParent<PlayerControl>();
        tpscam = home.camscript;
        home.fpscam = gameObject;

        guistyle = new GUIStyle();
        guistyle.fontSize = sizeviseur;
        guistyle.normal.textColor = Color.white;

        if (PlayerPrefs.GetInt("mod") == 1) //mod == 1 : splitted screen
        {
            if (int.Parse(home.photonView.instantiationData[0].ToString()) == 0)
            {
                GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
            }
            else
            {
                GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0f, 1f, 1f);
                //GetComponentInChildren<AudioListener>().enabled = false;
            }
        }

        gameObject.SetActive(false);
    }
    void Update()
    {
        if (home.isMine == false && PhotonNetwork.connected == true)
        {
            return;
        }

        transform.parent.eulerAngles = new Vector3(0f, tpscam.m_LookAngle + 60, tpscam.m_TiltAngle);
    }
    void OnGUI()
    {
        if (viseur)
        {
            if (home.screen == 0)
            {
                adapt = 0;
            }
            else if (home.screen == 1)
            {
                adapt = Screen.width / 4;
            }
            else if (home.screen == 2)
            {
                adapt = 3 * Screen.width / 4;
            }
            GUI.Label(new Rect(adapt, Screen.height / 2, 200, 200), "+", guistyle);
        }
    }


}
