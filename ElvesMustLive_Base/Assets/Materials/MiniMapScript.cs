using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour {
    public RenderTexture texture;

    public Material mat;
    public PlayerControl home;

	// Use this for initialization
	void Start () {
        home.mapCam.targetTexture = texture;
        mat.mainTexture = texture;
        GetComponent<UITexture>().material = mat;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
