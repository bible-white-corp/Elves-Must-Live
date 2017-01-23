using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtalScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Shootable")
        {
            // Un ennemie est passé
            // compteur -= 1;
            Destroy(coll.gameObject);
        }
    }
}
