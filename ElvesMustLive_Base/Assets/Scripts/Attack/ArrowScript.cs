using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    int AttackDamage = 10;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {

            Debug.Log(other.gameObject);
            try
            {
                other.GetComponent<Health>().TakeDamage(AttackDamage);
                Debug.Log("You touch " + other.gameObject);
            }
            catch (System.Exception)
            {
                Debug.Log("You fail your arrow in " + other.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
