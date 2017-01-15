using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWASDMov : MonoBehaviour 
{

	Vector3 movement;
	public float playerSpeed;

	void Awake () 
	{
	}
	

	void FixedUpdate() 
	{
		float h = Input.GetAxisRaw ("Horizontal") * Time.deltaTime * playerSpeed;
		float v = Input.GetAxisRaw ("Vertical") * Time.deltaTime * playerSpeed;
		transform.Translate (h, 0, v);
	}
}
