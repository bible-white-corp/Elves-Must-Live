using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CINEMATIQUE : MonoBehaviour {

    bool b1 = false;
    bool b2 = false;
    bool b3 = false;
    bool b4 = false;
    bool b5 = false;
    bool b6 = false;
    bool b7 = false;
    bool b8 = false;
    bool b9 = false;
    bool b = false;

    public NavMeshAgent gard;
    public Animator anim;
    public Transform des;
    public Transform des2;

    public NavMeshAgent ennemy;
    public Animator enn;

    public float time = 0;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetFloat("tt", 35f);
        gard.enabled = false;
        ennemy.enabled = false;
        enn.SetBool("InMov", true);
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (!b && time > 2)
        {
            ennemy.enabled = true;
            ennemy.destination = des.position;
        }
        if (!b1 && time > 8.7)
        {
            b1 = true;
            gard.enabled = true;
            gard.destination = des.position;
        }
        if (!b2 && time > 15)
        {
            gard.destination = ennemy.gameObject.transform.position;
        }
        if (!b2 && time > 15.5)
        {
            b2 = true;
            anim.SetBool("atk", true);
            gard.enabled = false;
            
        }
        if (!b9 && time > 15.57f)
        {
            b9 = true;
            enn.SetTrigger("Died");
            ennemy.enabled = false;
        }
        if (!b3 && time > 16)
        {
            b3 = true;
            gard.enabled = true;
            gard.speed = 2.5f;
            gard.destination = transform.position;
        }
        if (!b4 && time > 17)
        {
            b4 = true;
            anim.SetTrigger("idle");
            gard.enabled = false;
        }
        if (!b5 && time > 18)
        {
            b5 = true;
            GetComponent<Animator>().SetTrigger("a");
        }
        if (!b6 && time > 32)
        {
            b6 = true;
            gard.enabled = true;
            gard.destination = des2.position;
            anim.SetTrigger("mov");
        }
        if (!b7 && time > 37)
        {
            b7 = true;
            gard.enabled = false;
            anim.SetTrigger("idle");
        }
    }
}
