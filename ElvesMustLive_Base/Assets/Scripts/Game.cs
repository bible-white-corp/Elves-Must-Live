using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public GameObject global;
    public GameObject tchat;
    public WaveGenerator wave;
    public bool Splited;
    public bool Online;
    public bool SinglePlayer;

    public GameMode mode;

    public bool paused = false;


    // Use this for initialization
    void Awake()
    {

        global = gameObject;
        if (PlayerPrefs.GetInt("mod") == 1)
        {
            Splited = true;
        }
        /////////////////////////////////////////////////
        wave = gameObject.AddComponent<WaveGenerator>();
        mode = gameObject.AddComponent<Endless>();
        wave.mode = mode;
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Animator>().SetBool("Skip", true);
        }

        if (Input.GetKey("k"))
        {
        //    GameObject.FindGameObjectWithTag("Shootable").GetComponent<Health>().TakeDamage(31);
        }

        if (Input.GetKeyDown("p"))
        {
            PhotonNetwork.InstantiateSceneObject("Boss2", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
        }
        if (Input.GetKeyDown("j"))
        {
            PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
        }
        if (Input.GetKeyDown("k"))
        {
            PhotonNetwork.InstantiateSceneObject("Assassin", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
        }
		if (Input.GetKeyDown("o"))
		{
			PhotonNetwork.InstantiateSceneObject("MOB_Sapeur", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
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

    public void PauseGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
        }
    }




}
