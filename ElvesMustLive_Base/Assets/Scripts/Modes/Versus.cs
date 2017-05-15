using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Versus : MonoBehaviour 
{
	public List<string> ennemies = new List<string>();
	bool wave;
	int level;
	Queue<KeyValuePair<string, float>> queue1;
	Queue<KeyValuePair<string, float>> queue2;
	KeyValuePair<string, float> currentmonster1;
	KeyValuePair<string, float> currentmonster2;
	public GameObject spawn1;
	public GameObject spawn2;
	public int PV1 = 10;
	public int PV2 = 10;
	float timer1;
	float timer2;
	bool ended1;
	bool ended2;
	bool game;
	float timer;
	int winner;
	float timerbeforequit;

	void Start () 
	{
		timerbeforequit = 0;
		game = true;
		wave = false;
		spawn1 = GameObject.Find ("Spawn1");
		spawn2 = GameObject.Find ("Spawn2");
		bool ended1 = false;
		bool ended2 = false;
		timer = 0;
		timer1 = 0f;
		timer2 = 0f;
		queue1 = new Queue<KeyValuePair<string, float>>();
		queue2 = new Queue<KeyValuePair<string, float>>();
		ennemies.Add("Assassin");
		ennemies.Add("MOB_Sapeur");
		ennemies.Add("Ennemy0"); // pour plus de proportion d'ennemies classiques
		ennemies.Add("Ennemy0");
		level = 1;

	}

	// Update is called once per frame
	void Update () 
	{


		if (!game) 
		{

			//MESSAGE DE FIN AVEC LE WINNER (int winner = 1 ou 2)
			timerbeforequit += Time.deltaTime;
			if (timerbeforequit > 5) 
			{
				timerbeforequit = 0;
				PhotonNetwork.LeaveRoom ();
			}
		} 
		else 
		
		{
			if (wave) {
				if (!ended1) {
					if (timer1 > currentmonster1.Value) {
						timer1 = 0f;
						PhotonNetwork.InstantiateSceneObject (currentmonster1.Key, spawn1.transform.position, Quaternion.identity, 0, new object[] { });
						if (queue1.Count == 0) {
							ended1 = true;
						} else {
							currentmonster1 = queue1.Dequeue ();
						}
					} else {
						timer1 += Time.deltaTime;
					}
				}
				if (!ended2) {
					if (timer2 > currentmonster2.Value) {
						timer2 = 0f;
						PhotonNetwork.InstantiateSceneObject (currentmonster2.Key, spawn2.transform.position, Quaternion.identity, 0, new object[] { });
						if (queue2.Count == 0) {
							ended2 = true;
						} else {
							currentmonster2 = queue2.Dequeue ();
						}
					} else {
						timer2 += Time.deltaTime;
					}
				}
				if (ended1 && ended2) {
					wave = false;
				}
			} else {
				timer += Time.deltaTime;
				if (timer > 20) {
					timer = 0;
					level += 1;
					wave = true;
					queue1 = LoadNextLevel (queue1);
					queue2 = LoadNextLevel (queue2);
					ended1 = false;
					ended2 = false;
				}
			}
			if (PV1 < 0 || PV2 < 0) 
			{
				game = false;
				if (PV1 < 0) {
					winner = 2;
				} else {
					winner = 1;
				}
			}
		}
	}

	Queue<KeyValuePair<string, float>> LoadNextLevel(Queue<KeyValuePair<string, float>> queue)
	{

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

	public void AddMonster (string monster, int player)
	{
		if (player == 1) 
		{
			queue1.Enqueue (new KeyValuePair<string, float>(monster, 0.5f));
		} 
		else 
		{
			queue2.Enqueue (new KeyValuePair<string, float>(monster, 0.5f));
		}
	}
		

	 bool HasNextLevel()
	{
		return true;
	}
}

