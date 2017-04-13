using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

    Game game;

    public GameMode mode;

    public int count = -1; // Ennemies restants
    public float ennemyTime = 5;
    public bool wave = false;

    public float time;
    Queue<KeyValuePair<string, int>> currentWave = new Queue<KeyValuePair<string, int>>();
    KeyValuePair<string, int> currentEnnemy = new KeyValuePair<string, int> (null, 0);
    bool wait = false;

    // Use this for initialization
    void Start () {
        currentWave = mode.LoadNextLevel();
        count = currentWave.Count;
    }
	
	// Update is called once per frame
	void Update () {
        if (!PhotonNetwork.isMasterClient) {
            return;
        }
        
        if (wave)
        {
            if (!wait)
            {
                currentEnnemy = currentWave.Dequeue();
                time = currentEnnemy.Value;
                wait = true;
            }
            
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = ennemyTime;
                PhotonNetwork.InstantiateSceneObject(currentEnnemy.Key, gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                count = currentWave.Count; // Maybe send via network.

                wait = false;
                if (currentWave.Count == 0)
                {
                    wave = false;
                    currentWave = mode.LoadNextLevel();
                    count = currentWave.Count;
                }
            }
        }

        if (Input.GetKey(KeyCode.Return))
        {
            wave = true;
            //Afficher un texte "Press Enter pour lancer la prochaine vague."
        }
    }
}
