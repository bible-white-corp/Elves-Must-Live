using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    Animator anim;
    List<GameObject> weapon = new List<GameObject>();
    public int CurrentW = 0;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponentInParent<Animator>();
            foreach (Transform child in gameObject.transform)
        {
            Debug.Log(child.gameObject);
            weapon.Add(child.gameObject);
        }
        ChangeW(0);
    }
	
	// Update is called once per frame  
	void Update () {

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Debug.Log("Change weapon (+)");
            ChangeW(1);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Debug.Log("Change weapon (-)");
            ChangeW(-1);
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
