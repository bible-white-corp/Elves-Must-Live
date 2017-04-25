using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPScript : MonoBehaviour {

    public GameObject TpPosition;
    public bool JustTP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (TpPosition.GetComponent<TPScript>().JustTP)
            {
                return;
            }
            JustTP = true;
            other.transform.position = TpPosition.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TpPosition.GetComponent<TPScript>().JustTP = false;
    }
}
