using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public int maxLife = 500;
    public GameObject door;
    int woodLife;

	// Use this for initialization
	void Start () {
        woodLife = maxLife;	
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Shootable")
        {
            woodLife -= 1;
        }
        else if (!door.GetActive() && other.tag == "Player")
        {
            door.SetActive(true);
            woodLife = maxLife;
        }
    }
    // Update is called once per frame
    void Update () {
        if (woodLife < 0)
        {
            door.SetActive(false);
        }
	}
}
