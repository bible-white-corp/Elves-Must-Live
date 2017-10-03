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
    public bool cheats;
    public bool paused = false;
	Animator anim;
	bool endpreview = false;

    public int globalLife = 10; //Ennemies qui traversent le portail
    public int MAXglobalLife = 10;
    public bool ennemyInMap;

    public List<PlayerControl> gamers = new List<PlayerControl>();

    // Use this for initialization
    void Awake()
    {
		anim = GetComponent<Animator> ();
        if (PlayerPrefs.HasKey("cheat"))
        {
            cheats = PlayerPrefs.GetInt("cheat") == 1;
        }
        else
        {
            cheats = false;
        }

		gamingmode = "";
        gamingmode = PlayerPrefs.GetString("Mode");
        global = gameObject;
    }

	void Start ()
	{
		
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
                mode = GetComponent<Tuto>();
                wave.tuto = true;
                break;
            default:
                break;
        }
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

        

		}

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetButtonDown("Submit") || Input.GetButtonDown("2-Submit") || Input.GetButtonDown("Cancel") || Input.GetButtonDown("2-Cancel"))
        {
            try
            {
                GetComponent<Animator>().SetBool("Skip", true);

            }
            catch
            {}
        }
        ennemyInMap = GameObject.FindGameObjectWithTag("Shootable") != null;

		if (!endpreview && anim.enabled == false) 
		{
			endpreview = true;
			if (PlayerPrefs.GetInt("mod") == 1)
			{
				Splited = true;
				GUI.color = Color.black;
				GUI.Box(new Rect(Screen.width / 2, 0, 5, Screen.height), "");
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
