using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapeur_InitiateDestination : MonoBehaviour {

	public Transform FirstDestination;
	Sapeur_Mov script;
	void Start () 
	{
		script = GetComponent<Sapeur_Mov>();
		FirstDestination = GameObject.Find("Destination1").transform;
		script.ChangeDestination(FirstDestination);
	}
}
