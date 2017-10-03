using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : Photon.MonoBehaviour {

    int AttackDamage = 10;
    public Rigidbody rigid;
    float time;

    public int from;

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
        if (time > 10f)
        {
            PhotonNetwork.Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!photonView.isMine || other.isTrigger) // Pour ne pas détecter les milliers de triggers qui servent de range.
        {
            return;
        }
        if (other.tag != "Player") //
        {

            Debug.Log(other.gameObject);
            try
            {
                other.GetComponent<Health>().TakeDamage(AttackDamage, from); 
                // Faudrais le send by the network, la fleche va tellement vite que les autres recoivent pas la collision
                // (Un RPC sur le script health des ennemies)
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
