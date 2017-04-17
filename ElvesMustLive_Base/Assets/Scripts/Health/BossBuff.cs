using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBuff : MonoBehaviour {

	public int ArmorBuffAmount = 5;
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Shootable") 
		{
			other.GetComponent<Health> ().Armor = ArmorBuffAmount;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Shootable") 
		{
			other.GetComponent<Health> ().Armor = 0;
		}
	}

}
