using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    int AttackDamage = 10;
    public Rigidbody rigid;

	// Use this for initialization
	void Start ()
    {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rigid.AddForce(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.y));
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
