using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public GameObject global;
    public bool Splited;
    public bool Online;
    public bool SinglePlayer;   

    // Use this for initialization
    void Awake()
    {
        global = gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("k"))
        {
            GameObject.FindGameObjectWithTag("Shootable").GetComponent<Health>().TakeDamage(31);
        }

        if (Input.GetKeyDown("j"))
        {
            PhotonNetwork.InstantiateSceneObject("Ennemy", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
        }
    }




}
