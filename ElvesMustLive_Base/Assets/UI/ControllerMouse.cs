using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMouse : MonoBehaviour {

    public bool click;
    public UIControl UI;
    public bool active;
    public float speed;
    // Use this for initialization
    void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            return;
        }
        if (Input.GetButtonDown("2-Jump"))
        {
            click = true;
        }
        if (Input.GetButtonUp("2-Jump"))
        {
            click = false;
        }
        if (Input.GetAxis("2-Horizontal") != 0)
        {
            this.transform.position += new Vector3(Input.GetAxis("2-Horizontal") * speed, 0, 0);
        }
        if (Input.GetAxis("2-Vertical") != 0)
        {
            this.transform.position += new Vector3(0, Input.GetAxis("2-Vertical") * speed, 0);
        }
    }

    public void Active(bool b)
    {
        if (!b)
        {
            active = false;
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            active = true;
            GetComponent<Renderer>().enabled = true;
            GetComponent<Collider>().enabled = true;
        }
    }
}
