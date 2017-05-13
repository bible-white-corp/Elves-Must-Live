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
    public PlayerControl masterClient;
    public GameMode mode;

    public bool paused = false;

    public int globalLife = 10; //Ennemies qui traversent le portail

    public bool ennemyInMap;

    // Use this for initialization
    void Awake()
    {

        global = gameObject;
        if (PlayerPrefs.GetInt("mod") == 1)
        {
            Splited = true;
        }

    }



    public void InitWave()
    {
        /////////////////////////////////////////////////
        wave = gameObject.AddComponent<WaveGenerator>();
        Debug.Log("Mode : " + PlayerPrefs.GetString("Mode"));
        switch (PlayerPrefs.GetString("Mode"))
        {
            case "History":
                mode = gameObject.AddComponent<History>();
                break;
            case "Endless":
                mode = gameObject.AddComponent<Endless>();
                break;
            case "Tuto":
                break;
            default:
                break;
        }

        /*if (mode == null)
        {
            mode = gameObject.AddComponent<Endless>();
        }*/

        wave.mode = mode;
        mode.wave = wave;
    }

    // Update is called once per frame
    void Update()
    {
        if (globalLife < 0)
        {
            Debug.Log("You lost");
        }
        ennemyInMap = GameObject.FindGameObjectWithTag("Shootable") != null;
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (Localization.language == "Français")
            {
                Localization.language = "English";
            }
            else
            {
                Localization.language = "Français";
            }
            Debug.Log(Localization.language);
        }
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
