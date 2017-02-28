using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placability : MonoBehaviour {

	Prerenducollision script;
	bool IsPlacable;

	void Start () 
	{
		script = GetComponentInParent<Prerenducollision> ();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		IsPlacable = true;
	}
	void LateUpdate () 
	{
		script.IsPlacable (IsPlacable);
	}
	void OnTriggerStay(Collider coll)
	{
		this.IsPlacable =false;
	}

}
