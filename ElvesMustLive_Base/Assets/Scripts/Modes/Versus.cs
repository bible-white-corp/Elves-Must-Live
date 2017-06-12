using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Versus : MonoBehaviour 
{
	public List<string> ennemies = new List<string>();
	public bool wave;
	public int level;
	Queue<KeyValuePair<string, float>> queue1;
	Queue<KeyValuePair<string, float>> queue2;
	KeyValuePair<string, float> currentmonster1;
	KeyValuePair<string, float> currentmonster2;
	public GameObject spawn1;
	public GameObject spawn2;
	public int PV1 = 15;
	public int PV2 = 15;
    public int PVMax = 15;
	public float timer1;
	public float timer2;
	public bool ended1;
	public bool ended2;
	public bool game;
	public float timer;
	public int winner;
	public float timerbeforequit;

    public bool playing = false;
    public bool finish = false;

    public List<PlayerControl> team1 = new List<PlayerControl>();
    public List<PlayerControl> team2 = new List<PlayerControl>();

    Game script;

    void Start () 
	{
        PV1 = PVMax;
        PV2 = PVMax;
		timerbeforequit = 0;
		game = true;
		wave = false;
		spawn1 = GameObject.Find ("Spawn1");
		spawn2 = GameObject.Find ("Spawn2");
		//bool ended1 = false;
		//bool ended2 = false;
		timer = 0;
		timer1 = 0f;
		timer2 = 0f;
		queue1 = new Queue<KeyValuePair<string, float>>();
		queue2 = new Queue<KeyValuePair<string, float>>();
        ennemies.Add("Assassin");
        ennemies.Add("Assassin");
        ennemies.Add("Assassin");
        ennemies.Add("Assassin");
        ennemies.Add("Assassin");
        ennemies.Add("MOB_Sapeur");
        ennemies.Add("MOB_Sapeur");
        ennemies.Add("MOB_Sapeur");
        ennemies.Add("MOB_Sapeur");
        ennemies.Add("Ennemy0"); // pour plus de proportion d'ennemies classiques
        ennemies.Add("Ennemy0");
        ennemies.Add("Ennemy0");
        ennemies.Add("Ennemy0");
        ennemies.Add("Ennemy0");
        ennemies.Add("Ennemy0");
        ennemies.Add("Ennemy0");
        ennemies.Add("Ennemy0");
        ennemies.Add("Ennemy0");
        ennemies.Add("Ennemy0");
        ennemies.Add("Ennemy0");
        ennemies.Add("Boss1");
        ennemies.Add("Boss1");
        ennemies.Add("Boss2");
        ennemies.Add("Boss3");
        ennemies.Add("Ennemy0");
        level = 1;
        script = GetComponent<Game>();

        currentmonster1 = new KeyValuePair<string, float>("Ennemy0", 0f);
        currentmonster2 = new KeyValuePair<string, float>("Ennemy0", 0f);
    }

    public Vector3 AddPlayer(PlayerControl player)
    {
        Vector3 trans = Vector3.zero;
        if (team2.Count < team1.Count)
        {
            team2.Add(player);
            //player.ShowHistory("team1");
            player.photonView.RPC("ShowInfo", PhotonTargets.All, "team2");
            player.gameObject.transform.position = spawn2.transform.position;
            trans = spawn2.transform.position;
        }
        else
        {
            team1.Add(player);
            player.photonView.RPC("ShowInfo", PhotonTargets.All, "team1");
            //player.ShowHistory("team2");
            player.gameObject.transform.position = spawn1.transform.position;
            trans = spawn1.transform.position;
        }
        if (team1.Count > 0 && team2.Count > 0)
        {
            playing = true;
            foreach (var item in team1)
            {
                item.photonView.RPC("ShowInfoRed", PhotonTargets.All, "");
            }
            foreach (var item in team2)
            {
                item.photonView.RPC("ShowInfoRed", PhotonTargets.All, "");
            }
        }
        return trans;
    }

    public void RemovePlayer(PlayerControl player)
    {
        if (team1.Contains(player))
        {
            team1.Remove(player);
        }
        else
        {
            team2.Remove(player);
        }
        if (team1.Count > 0 && team2.Count > 0)
        { }
        else
        {
            playing = false;
        }
    }

    public int GetCount(PlayerControl player)
    {
        if (team1.Contains(player))
        {
            return queue1.Count;
        }
        else
        {
            return queue2.Count;
        }
    }

    public Vector3 GetSpawn(PlayerControl player)
    {
        if (team1.Contains(player))
        {
            return spawn1.transform.position;
        }
        else
        {
            return spawn2.transform.position;
        }
    }

    public float GetVillageValue(PlayerControl player)
    {
        if (team1.Contains(player))
        {
            return (float)PV1 / (float)PVMax;
        }
        else
        {
            return (float)PV2 / (float)PVMax;
        }
    }

    // Update is called once per frame
    void Update () 
	{
        if (!PhotonNetwork.isMasterClient)
        {
            return;
        }

        if (!playing)
        {
            foreach (var item in team1)
            {
                item.photonView.RPC("ShowInfoRed",PhotonTargets.All,"less_than_2");
            }
            foreach (var item in team2)
            {
                item.photonView.RPC("ShowInfoRed", PhotonTargets.All, "less_than_2");
            }
            return;
        }


		if (!game) 
		{
            Game script = GetComponent<Game>();
            if (!finish)
            {
                if (winner == 1)
                {
                    foreach (var item in team1)
                    {
                        item.photonView.RPC("ShowInfo",PhotonTargets.All, "victory_1");
                    }
                    foreach (var item in team2)
                    {
                        item.photonView.RPC("ShowInfo", PhotonTargets.All, "loose_2");
                    }
                }
                else
                {
                    foreach (var item in team1)
                    {
                        item.photonView.RPC("ShowInfo", PhotonTargets.All, "loose_1");
                    }
                    foreach (var item in team2)
                    {
                        item.photonView.RPC("ShowInfo", PhotonTargets.All, "victory_2");
                    }
                }
            }
            timerbeforequit += Time.deltaTime;
			if (timerbeforequit > 5) 
			{
				timerbeforequit = 0;
                script.masterClient.photonView.RPC("QuitRoom", PhotonTargets.All);
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
			if (PV1 <= 0 || PV2 <= 0) 
			{
				game = false;
				if (PV1 <= 0) {
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

        for (int i = 0; i < level; i++)
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
            queue.Enqueue(new KeyValuePair<string, float>(ennemies[UnityEngine.Random.Range(0, ennemies.Count)], UnityEngine.Random.Range(0f, maxWait)));
        }
        return queue;
	}

	public void AddMonster (string monster, PlayerControl player)
	{
		if (team1.Contains(player)) 
		{
			queue2.Enqueue (new KeyValuePair<string, float>(monster, 0.5f));
		} 
		else 
		{
			queue1.Enqueue (new KeyValuePair<string, float>(monster, 0.5f));
		}
	}
		

	 bool HasNextLevel()
	{
		return true;
	}
}

