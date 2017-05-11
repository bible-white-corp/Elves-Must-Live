using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endless : GameMode {

    public List<string> ennemies = new List<string>();

	// Use this for initialization
	void Start () {
        ennemies.Add("Assassin");
        ennemies.Add("MOB_Sapeur");
        ennemies.Add("Ennemy0"); // pour plus de proportion d'ennemies classiques
        ennemies.Add("Ennemy0");

        level = 1;
        wave = GetComponent<WaveGenerator>();
        wave.currentWave = LoadNextLevel();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override Queue<KeyValuePair<string, float>> LoadNextLevel()
    {
        Queue<KeyValuePair<string, float>> queue = new Queue<KeyValuePair<string, float>>();
        
        //Algo pour générer des queues de + en + hardcore en fonction du level

        for (int i = 0; i < Mathf.Pow(2,level-1); i++)
        {
            float maxWait = 5f - level;
            if (maxWait < 1f)
            {
                maxWait = 1f;
            }
            queue.Enqueue(new KeyValuePair<string, float>(ennemies[UnityEngine.Random.Range(0, ennemies.Count)], 2f));
            queue.Enqueue(new KeyValuePair<string, float>(ennemies[UnityEngine.Random.Range(0, ennemies.Count)], UnityEngine.Random.Range(0f, maxWait)));
            queue.Enqueue(new KeyValuePair<string, float>(ennemies[UnityEngine.Random.Range(0, ennemies.Count)], UnityEngine.Random.Range(0f, maxWait)));
            queue.Enqueue(new KeyValuePair<string, float>(ennemies[UnityEngine.Random.Range(0, ennemies.Count)], UnityEngine.Random.Range(0f, maxWait)));
            queue.Enqueue(new KeyValuePair<string, float>("Boss"+((i%3)+1), 4f));
        }

        return queue;
    }


    public override bool HasNextLevel()
    {
        return true;
    }
}
