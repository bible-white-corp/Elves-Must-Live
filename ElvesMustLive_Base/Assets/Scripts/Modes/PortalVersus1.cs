using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalVersus1 : MonoBehaviour {

	Versus script;
	void Start () 
	{
		script = GameObject.Find ("GameManager").GetComponent<Versus> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Shootable") 
		{
			PhotonNetwork.Destroy (coll.gameObject);
			script.PV1-=1;
		}
	}
}
