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
		if (coll.tag == "Ground")
		{
			this.NearGround = true;
		}
	}

	void OnTriggerExit (Collider coll)
	{
		if (coll.tag == "Ground")
		{
			this.NearGround = false;
		}
	}
	public void IsPlacable(bool placable)
	{
		this.placable = placable;
	}
}
