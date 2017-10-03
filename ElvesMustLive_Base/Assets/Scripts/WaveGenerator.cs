using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

    public Game game;
    public GameMode mode;
    
    //public float ennemyTime = 5;
    public bool wave = false;
	public int map;
    public float time;
    public Queue<KeyValuePair<string, float>> currentWave;
	public int ennemiesleft;
    public KeyValuePair<string, float> currentEnnemy = new KeyValuePair<string, float> (null, 0);
	GameObject SecondSpwn;
	Random rand;
	bool leaveroom;
    public bool endGame;
	float timerbeforeleaving;
    public bool winner = false;

    public bool tuto;
    // Use this for initialization
    void Start () {
		timerbeforeleaving = 0f;
		leaveroom = false;
		rand = new Random();
		map = PlayerPrefs.GetInt ("Histoire");
		SecondSpwn = GameObject.Find("Spawn2");
        game = GetComponent<Game>();
		ennemiesleft = 0;
    }
	
    public bool StartWave()
    {
        if (tuto) {
            return false;
        }
        if (!wave && mode.HasNextLevel())
        {
            currentWave = mode.LoadNextLevel();
			ennemiesleft = currentWave.Count;
            mode.level += 1;
        }
        else
        {
            return false;
        }
        LoadEnnemy();
        wave = true;
        return true;
    }

	// Update is called once per frame
	void Update () 
	{
        if (!PhotonNetwork.isMasterClient || tuto) 
		{
            return;
        }
		if (leaveroom) 
		{
			timerbeforeleaving += Time.deltaTime;
			if (timerbeforeleaving > 5) 
			{
				timerbeforeleaving = 0;
                if (winner && PlayerPrefs.GetString("Mode") == "History" && UnityEngine.SceneManagement.SceneManager.GetActiveScene() == UnityEngine.SceneManagement.SceneManager.GetSceneByName("Cave"))
                {
                    Debug.Log("LaunchCin");
                    game.masterClient.photonView.RPC("QuitRoom2", PhotonTargets.All);
                }
                else
                {

                    //Debug.Log("lllllllllllleaving");
                    game.masterClient.photonView.RPC("QuitRoom", PhotonTargets.All);
                }
			}
		}
        if (wave)
        {
            
            time -= Time.deltaTime;
            if (time <= 0)
            {
                //time = ennemyTime;
				if (map == 2) 
				{
					int temp = Random.Range (1, 3);
					if (temp == 1 || mode.level == 1) 
					{
						PhotonNetwork.InstantiateSceneObject (currentEnnemy.Key, gameObject.transform.position, Quaternion.identity, 0, new object[] { });
					}
					else 
					{
						PhotonNetwork.InstantiateSceneObject (currentEnnemy.Key, SecondSpwn.transform.position, Quaternion.identity, 0, new object[] { });
					}
				}
				else
				{
					PhotonNetwork.InstantiateSceneObject (currentEnnemy.Key, gameObject.transform.position, Quaternion.identity, 0, new object[] { });
				}
				ennemiesleft -= 1;

				if (ennemiesleft == 0)
                {
                    wave = false;
                    if (!mode.HasNextLevel())
                    {
                        endGame = true;
                        return;
                    }                    
                }
                else
                {
                    LoadEnnemy();
                }
            }
        }
        else
        {
            if (!game.ennemyInMap && !endGame)
            {
                game.masterClient.MyUI.Info.enabled = true;
                game.masterClient.MyUI.Info.text = Localization.Get("LaunchWave");
            }
        }

        if (!leaveroom && endGame && !game.ennemyInMap)
        {
            game.masterClient.MyUI.Info.enabled = false;
            
            Finish();
        }
    }

    public void LoadEnnemy()
    {
        currentEnnemy = currentWave.Dequeue();
        time = currentEnnemy.Value;
    }

    public void Finish()
    {
        game.masterClient.MyUI.SetStory(Localization.Get("EndLevel"));
        Debug.Log("You Win this level");
        if (PlayerPrefs.GetString("Mode") == "History")
        {
            PlayerPrefs.SetInt("Histoire", PlayerPrefs.GetInt("Histoire") + 1);
			//PhotonNetwork.LeaveRoom ();
			
        }
        leaveroom = true;
        winner = true;
    }

    public void Loose()
    {
        game.masterClient.MyUI.SetStory(Localization.Get("LooseLevel"));
        endGame = true;
        leaveroom = true;
        winner = false;
    }
}
