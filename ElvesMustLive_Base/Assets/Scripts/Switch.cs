using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    Animator anim;
    float timer;
    bool timeout = false;
    List<GameObject> weapon = new List<GameObject>();
    public int CurrentW = 0;

    PlayerControl home;

	// Use this for initialization
	void Start ()
    {
        home = GetComponentInParent<PlayerControl>();
        anim = home.anim;
        foreach (Transform child in gameObject.transform)
        {
            Debug.Log(child.gameObject);
            weapon.Add(child.gameObject);
        }
        ChangeW(0);
    }
	
	// Update is called once per frame  
	void Update () 
	{
        if (home.isMine == false && PhotonNetwork.connected == true)
        {
            return;
        }

        if (timeout)
		{
			timer += Time.deltaTime;
			if (timer > 0.3f)
			{
				timer = 0f;
				timeout = false;
			}
		}
		else
		{
        	if (Input.GetAxis("Mouse ScrollWheel") > 0 && !anim.GetCurrentAnimatorStateInfo(0).IsTag("atk"))
        	{
        	    Debug.Log("Change weapon (+)");
        	    ChangeW(1);
        	    timeout = true;
        	}
        	if (Input.GetAxis("Mouse ScrollWheel") < 0 && !anim.GetCurrentAnimatorStateInfo(0).IsTag("atk"))
        	{
        	    Debug.Log("Change weapon (-)");
        	    ChangeW(-1);
        	    timeout = true;
        	}

    	}

    }

    public void ChangeW(int nb)
    {
        weapon[CurrentW].SetActive(false);
        anim.SetBool(weapon[CurrentW].tag, false);

        CurrentW += nb;
        if (CurrentW < 0)
        {
            CurrentW = weapon.Count - 1;
        }
        else if (CurrentW >= weapon.Count)
        {
            CurrentW = 0;
        }

        weapon[CurrentW].SetActive(true);
        anim.SetBool(weapon[CurrentW].tag, true);
    }


}
