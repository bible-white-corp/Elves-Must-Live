using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateComponent : MonoBehaviour {

	public GameObject FirstDestination;
	EnnemyMov1 script;
	void Awake () 
	{
		script = GetComponent<EnnemyMov1> ();
		FirstDestination = GameObject.Find("Destination1");
		script.ChangeDestination (FirstDestination);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
