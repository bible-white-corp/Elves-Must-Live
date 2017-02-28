using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prerenducollision : MonoBehaviour 
{
	bool placable;
	bool NearGround;
	RayCast script;

	void Start () 
	{
		placable = true;
		NearGround = false;
		script = GetComponentInParent<RayCast> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		this.NearGround = false;
	}

	void LateUpdate()
	{
		script.IsPlacable (placable);
		script.IsGrounded (NearGround);
	}

	void OnTriggerStay(Collider coll)
	{
		Debug.Log ("touch");
		this.NearGround = true;
	}

	public void IsPlacable(bool placable)
	{
		this.placable = placable;
	}
}
