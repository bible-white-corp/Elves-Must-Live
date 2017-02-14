using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : Photon.MonoBehaviour {

    int AttackDamage = 10;
    public Rigidbody rigid;
    float time;

	// Use this for initialization
	void Start ()
    {
        rigid = GetComponent<Rigidbody>();
        time = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        if (time > 20f)
        {
            PhotonNetwork.Destroy(gameObject);
        }
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

            PhotonNetwork.Destroy(gameObject);
        }
    }
}
