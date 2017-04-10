using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

    Game game;

    public int count = 15; // Ennemies restants
    public float ennemyTime = 5;
    public bool wave = false;

    public float time;
    Queue<KeyValuePair<string, int>> currentWave = new Queue<KeyValuePair<string, int>>();
    KeyValuePair<string, int> currentEnnemy = new KeyValuePair<string, int> (null, 0);
    bool wait = false;

    // Use this for initialization
    void Start () {

        currentWave = LoadLevel(1);
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
                count -= 1; // Maybe send via network.

                wait = false;
                if (count <= 0)
                {
                    wave = false;
                }
            }
        }

        if (Input.GetKey(KeyCode.Return))
        {
            wave = true;
            //Afficher un texte "Press Enter pour lancer la prochaine vague."
        }
    }

    public Queue<KeyValuePair<string, int>> LoadLevel(int lvl)
    {
        Queue<KeyValuePair<string, int>> newlvl = new Queue<KeyValuePair<string, int>>();
        switch (lvl)
        {
            case 1:
                newlvl.Enqueue(new KeyValuePair<string, int>("Ennemy", 0)); //Ennemy prefab + time in sec between ennemies.
                newlvl.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                newlvl.Enqueue(new KeyValuePair<string, int>("Ennemy", 5)); // KeyValuePair = Tuple
                newlvl.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                newlvl.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                newlvl.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                newlvl.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                newlvl.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                newlvl.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                break;

            default:
                break;
        }
        return newlvl;
    }
}
