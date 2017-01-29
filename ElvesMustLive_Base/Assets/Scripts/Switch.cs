using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    List<GameObject> weapon = new List<GameObject>();
    public int CurrentW = 0;

	// Use this for initialization
	void Start () {
        foreach (Transform child in gameObject.transform)
        {
             Debug.Log(child.gameObject);
            weapon.Add(child.gameObject);
        }
        ChangeW();
    }
	
	// Update is called once per frame  
	void Update () {

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Debug.Log("Change weapon (+)");
            CurrentW++;
            ChangeW();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Debug.Log("Change weapon (-)");
            CurrentW--;
            ChangeW();
        }

    }

    public void ChangeW()
    {
        foreach (var go in weapon)
        {
            go.SetActive(false);
        }
        if (CurrentW < 0)
        {
            CurrentW = weapon.Count - 1;
        }
        else if (CurrentW >= weapon.Count)
        {
            CurrentW = 0;
        }
        weapon[CurrentW].SetActive(true);
    }


}
