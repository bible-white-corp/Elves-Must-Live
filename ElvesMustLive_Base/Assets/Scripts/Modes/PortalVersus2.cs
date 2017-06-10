using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalVersus2 : MonoBehaviour {

	Versus script;
	void Start () 
	{
		script = GameObject.Find ("GameManager").GetComponent<Versus> ();
	}
		
	void Update () 
	{

	}
	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Shootable") 
		{
			PhotonNetwork.Destroy (coll.gameObject);
			script.PV2-=1;
		}
	}
}
