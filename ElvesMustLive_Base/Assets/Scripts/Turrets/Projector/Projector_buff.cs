using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Projector_buff : MonoBehaviour {

	public float SpeedReduction;


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Shootable") 
		{
			other.GetComponent<NavMeshAgent> ().speed -= SpeedReduction;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Shootable") 
		{
			other.GetComponent<NavMeshAgent> ().speed += SpeedReduction;
		}
	}
	
}
