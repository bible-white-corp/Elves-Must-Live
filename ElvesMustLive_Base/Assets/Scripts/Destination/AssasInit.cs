using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssasInit : MonoBehaviour {

	public Transform FirstDestination;
	AssasMov script;
	void Start () 
	{
		script = GetComponent<AssasMov>();
		FirstDestination = GameObject.Find("Destination1").transform;
		script.ChangeDestination(FirstDestination);
	}

	// Update is called once per frame
	void Update () {

	}
}
