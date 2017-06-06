using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateDestination : MonoBehaviour {

	public Transform FirstDestination;
	EnnemyMov1 script;
    float time = 0;
    public bool ready = false;
    Animator animator;
	void Start () 
	{
        
		script = GetComponent<EnnemyMov1>();
        animator = script.animator;
        //FirstDestination = GameObject.Find("Destination1").transform;
        //script.ChangeDestination(FirstDestination);
    }
	
	// Update is called once per frame
	void Update () {
        
        time += Time.deltaTime;
        if (PlayerPrefs.GetFloat("tt") < time && !ready)
        {
            script.ChangeDestination(FirstDestination);
            PlayerPrefs.SetFloat("tt", time + 1.3f);
            animator.SetBool("InMov", true);
            Debug.Log("Send," + time);
            ready = true;
        }
	}
}
