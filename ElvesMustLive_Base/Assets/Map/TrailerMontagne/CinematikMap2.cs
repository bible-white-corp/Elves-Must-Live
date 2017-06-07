using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematikMap2 : MonoBehaviour {

    public GameObject boss;

	// Use this for initialization
	void Start () {
        foreach (var item in GameObject.FindGameObjectsWithTag("Shootable"))
        {
            item.transform.LookAt(boss.transform);
            Random.Range(0, 2);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
