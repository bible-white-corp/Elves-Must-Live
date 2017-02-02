using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class FPSCam : MonoBehaviour {

    Game game;

    FreeLookCam tpscam;

    GameObject target;
    Vector3 temp;


    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
        tpscam = game.playercam;
        game.fpscam = gameObject;
        gameObject.SetActive(false);

    }
    void Update()
    {
        transform.parent.eulerAngles = new Vector3(0f, tpscam.m_LookAngle + 60, tpscam.m_TiltAngle);
    }


}
