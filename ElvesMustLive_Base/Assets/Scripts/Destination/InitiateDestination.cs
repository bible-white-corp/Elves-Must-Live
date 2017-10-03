using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateDestination : MonoBehaviour {

	public Transform FirstDestination;
	EnnemyMov1 script;
	void Start () 
	{
		script = GetComponent<EnnemyMov1>();
        FirstDestination = GameObject.Find("Destination1").transform;
        script.ChangeDestination(FirstDestination);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
