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
        desti = transform.TransformDirection(Vector3.forward);

        Physics.Raycast(transform.position, desti, out hit, 10f);
        Debug.Log(hit.collider.tag);
        Debug.Log(hit.transform.position);
        if (hit.collider.tag == "Groud")
        {
            PhotonNetwork.Instantiate("Cannon", hit.point, Quaternion.identity, 0);
            Debug.Log("Fine");
        }

    }
}