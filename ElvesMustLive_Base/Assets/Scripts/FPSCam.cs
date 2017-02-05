using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class FPSCam : MonoBehaviour {

    PlayerControl home;

    FreeLookCam tpscam;

    GameObject target;
    Vector3 temp;


    private void Start()
    {
        home = GetComponentInParent<PlayerControl>();
        tpscam = home.camscript;
        home.fpscam = gameObject;
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


}
