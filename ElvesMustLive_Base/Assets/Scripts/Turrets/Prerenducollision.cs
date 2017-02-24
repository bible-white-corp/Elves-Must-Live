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
	void Update () 
	{
		script.IsGrounded (NearGround);
		script.IsPlacable (placable);
	}
	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Obstacle") 
		{
			placable = false;
		}
		if (coll.tag == "Ground") 
		{
			NearGround = true;
		}
	}
	void OnTriggerStay(Collider coll)
	{
		if (coll.tag == "Obstacle") 
		{
			placable = false;
		}
		if (coll.tag == "Ground") 
		{
			NearGround = true;
		}
	}
	void OnTriggerExit(Collider coll)
	{
		if (coll.tag == "Obstacle") 
		{
			placable = true;
		}
		if (coll.tag == "Ground") 
		{
			NearGround = false;
		}
	}
}
