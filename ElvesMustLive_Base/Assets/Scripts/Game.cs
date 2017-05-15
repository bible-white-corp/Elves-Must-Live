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
	public string gamingmode;

    public bool paused = false;

    public int globalLife = 10; //Ennemies qui traversent le portail

    public bool ennemyInMap;

    // Use this for initialization
    void Awake()
    {
		gamingmode = "";
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
		gamingmode = PlayerPrefs.GetString ("Mode");
		switch (gamingmode)
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
		if (gamingmode == "Versus") 
		{

		} 
		else 
		{
			if (globalLife < 0) {
                wave.Loose();
			}
			ennemyInMap = GameObject.FindGameObjectWithTag ("Shootable") != null;
        
			if (Input.GetKey (KeyCode.Space)) {
				GetComponent<Animator> ().SetBool ("Skip", true);
			}
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
