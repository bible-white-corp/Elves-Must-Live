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
    private GUIStyle guistyle;

    private void Start()
    {
        home = GetComponentInParent<PlayerControl>();
        tpscam = home.camscript;
        home.fpscam = gameObject;
        gameObject.SetActive(false);

        guistyle = new GUIStyle();
        guistyle.fontSize = sizeviseur;
        guistyle.normal.textColor = Color.white;
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
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200, 200), "+", guistyle);
        }
    }


}
