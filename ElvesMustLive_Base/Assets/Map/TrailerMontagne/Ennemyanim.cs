using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemyanim : MonoBehaviour {

    Animator anim;
    float time = 0;
    float max;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
        max = Random.Range(1.5f, 3.5f);
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > max)
        {
            max = Random.Range(1.5f, 3f);
            time = 0;
            int rand = Random.Range(0, 10);
            switch (rand)
            {
                case 0:
                case 1:
                    break;
                case 2:
                case 3:
                    anim.SetTrigger("idle2");
                    break;
                case 4:
                    anim.SetTrigger("idle1");
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    anim.SetTrigger("spe");
                    break;
                default:
                    break;
            }
        }
	}
}
