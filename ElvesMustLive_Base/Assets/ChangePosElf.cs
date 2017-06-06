using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangePosElf : MonoBehaviour {

    public Transform NextPosition;
    public Transform RandomPosition = null; // Laisser null si non utiliser
    public Transform RandomPosition2 = null; // Laisser null si non utiliser

    void Start()
    {
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Shootable")
        {
            int rand = Random.Range(0, 3);
            if (RandomPosition != null && rand == 1)
            {
                coll.GetComponent<NavMeshAgent>().SetDestination(RandomPosition.position);
            }
            else if(RandomPosition2 != null && rand == 2)
            {
                coll.GetComponent<NavMeshAgent>().SetDestination(RandomPosition2.position);
            } 
            else
            {
                coll.GetComponent<NavMeshAgent>().SetDestination(NextPosition.position);
            }
        }
    }
}
