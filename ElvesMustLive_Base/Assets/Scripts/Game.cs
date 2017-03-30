using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public GameObject global;
    public GameObject tchat;
    public bool Splited;
    public bool Online;
    public bool SinglePlayer;

    public int count; // Ennemies restants
    public float ennemyTime = 5;
    public bool wave = false;

    public float time;

    // Use this for initialization
    void Awake()
    {
        global = gameObject;
        if (PlayerPrefs.GetInt("mod") == 1)
        {
            Splited = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.isMasterClient && wave)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = ennemyTime;
                PhotonNetwork.InstantiateSceneObject("Ennemy", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                count -= 1; // Maybe send via network.
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            wave = !wave;
            time = ennemyTime;
        }

        if (Input.GetKey("k"))
        {
            GameObject.FindGameObjectWithTag("Shootable").GetComponent<Health>().TakeDamage(31);
        }

        if (Input.GetKeyDown("j"))
        {
            PhotonNetwork.InstantiateSceneObject("Ennemy", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
        }
        if (Input.GetKeyDown("t"))
        {
            tchat.SetActive(!tchat.activeSelf);
        }
    }
    private void OnGUI()
    {
        if (Splited)
        {
            GUI.color = Color.black;
            GUI.Box(new Rect(Screen.width / 2, 0, 5, Screen.height), "");
        }
    }




}
