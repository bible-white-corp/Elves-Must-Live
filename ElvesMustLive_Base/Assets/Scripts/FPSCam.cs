using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class FPSCam : MonoBehaviour {

    Game game;

    Transform rig;
    Transform pivot;
    Transform maincam;

    GameObject target;
    Vector3 temp;


    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
        game.fpscam = gameObject;
        gameObject.SetActive(false);

    }
    void Update()
    {

    }


}
