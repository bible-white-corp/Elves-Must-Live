using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public GameObject global;


    // Use this for initialization
    void Awake()
    {
        global = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("h"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(30);
        }

        if (Input.GetKey("k"))
        {
            GameObject.FindGameObjectWithTag("Shootable").GetComponent<Health>().TakeDamage(31);
        }

        if (Input.GetKeyDown("j"))
        {
            PhotonNetwork.InstantiateSceneObject("Ennemy", new Vector3(0f, 5f, 0f), Quaternion.identity, 0, new object[] { });
        }
        if (Input.GetKey("t"))
        {
            if (global == null)
            {
                global = (GameObject)Instantiate(Resources.Load("PersoAndCam"));
            }
        }
        if (Input.GetKeyDown("r"))
        {
            TestSpawn();
        }


    }
    [PunRPC]
    public void TestSpawn()
    {
        PhotonNetwork.InstantiateSceneObject("Test", transform.position, Quaternion.identity, 0, new object[] { });
    }



}
