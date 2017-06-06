using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class InitiateDestination : MonoBehaviour {

	public Transform FirstDestination;
	EnnemyMov1 script;
    float time = 0;
    public bool ready = false;
    Animator animator;
	void Start () 
	{
        
		//script = GetComponent<EnnemyMov1>();
        animator = GetComponent<Animator>();
        //FirstDestination = GameObject.Find("Destination1").transform;
        //script.ChangeDestination(FirstDestination);
    }
	
	// Update is called once per frame
	void Update () {
        
        time += Time.deltaTime;
        if (PlayerPrefs.GetFloat("tt") < time && !ready)
        {
            GetComponent<NavMeshAgent>().SetDestination(GameObject.Find("DD").transform.position);
            PlayerPrefs.SetFloat("tt", time + 1.3f);
            animator.SetBool("InMov", true);
            //Debug.Log("Send," + time);
            ready = true;
        }
	}
}
