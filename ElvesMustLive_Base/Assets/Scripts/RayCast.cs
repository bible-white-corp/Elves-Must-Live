using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

    Vector3 desti;
    RaycastHit hit;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void Cast()
    {
        Debug.Log(gameObject.name);
		if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit)) 
		{
			Debug.Log (hit.collider.tag);
			Debug.Log (hit.transform.position);
			if (hit.collider.tag == "Ground") 
			{
				PhotonNetwork.Instantiate ("Cannon", hit.point, Quaternion.identity, 0);
				Debug.Log ("Fine");
			}
		}
    }
}