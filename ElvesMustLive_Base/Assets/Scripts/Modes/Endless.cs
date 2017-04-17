using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endless : GameMode {

    public WaveGenerator wave;
    public int level;

	// Use this for initialization
	void Start () {
        level = 1;
        wave.mode = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override Queue<KeyValuePair<string, int>> LoadNextLevel()
    {
        level += 1;
        Queue<KeyValuePair<string, int>> queue = new Queue<KeyValuePair<string, int>>();
        switch (level) // J'aime les/la Switch <3 T'abuses...
        {
            case 1:
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0)); //Ennemy prefab + time in sec between ennemies.
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 5)); // KeyValuePair = Tuple
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                break;
            case 2:
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 0));
                queue.Enqueue(new KeyValuePair<string, int>("Ennemy", 5));
                break;
            default:
                Debug.Log("Win !");
                break;
        }
        //Algo pour générer des queues de + en + hardcore en fonction du level



        return queue;
    }
}
