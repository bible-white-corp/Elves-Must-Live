using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

    public Game game;

    public GameMode mode;
    
    //public float ennemyTime = 5;
    public bool wave = false;

    public float time;
    public Queue<KeyValuePair<string, float>> currentWave = new Queue<KeyValuePair<string, float>>();
    public KeyValuePair<string, float> currentEnnemy = new KeyValuePair<string, float> (null, 0);

    // Use this for initialization
    void Start () {
        game = GetComponent<Game>();
    }
	
    public bool StartWave()
    {
        if (!wave && mode.HasNextLevel())
        {
            currentWave = mode.LoadNextLevel();
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
	void Update () {
        if (!PhotonNetwork.isMasterClient) {
            return;
        }
        
        if (wave)
        {
            
            time -= Time.deltaTime;
            if (time <= 0)
            {
                //time = ennemyTime;
                PhotonNetwork.InstantiateSceneObject(currentEnnemy.Key, gameObject.transform.position, Quaternion.identity, 0, new object[] { });


                if (currentWave.Count == 0)
                {
                    wave = false;
                    if (!mode.HasNextLevel())
                    {
                        Finish();
                        return;
                    }
                    mode.level += 1;
                    currentWave = mode.LoadNextLevel();

                }
                else
                {
                    LoadEnnemy();
                }
            }
        }


    }

    public void LoadEnnemy()
    {
        currentEnnemy = currentWave.Dequeue();
        time = currentEnnemy.Value;
    }

    public void Finish()
    {
        Debug.Log("You Win");
    }
}
