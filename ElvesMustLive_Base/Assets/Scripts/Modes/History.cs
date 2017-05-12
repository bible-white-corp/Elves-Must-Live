using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : GameMode {

    public int Map;
    public int waveRemaining;

    Queue<KeyValuePair<string, float>> queue;

    public override bool HasNextLevel()
    {
        return waveRemaining != 0;
    }

    public override Queue<KeyValuePair<string, float>> LoadNextLevel()
    {
        queue = new Queue<KeyValuePair<string, float>>();
        //level++;
        switch (Map)
        {
            case 1:
                /////////////////////////////////////////// MAP 1
                switch (waveRemaining)
                {
			case 5:
				Add ("Ennemy0", 5f); // Vague 1
				Add ("Ennemy0", 5f);
				Add ("Ennemy0", 5f); // String dans ressource et temps qui le sépare du mob précédent.
				Add ("Ennemy0", 5f);
				break;
			case 4:
				Add ("Ennemy0", 5f); // Vague 2
				Add ("Ennemy0", 0.5f);
				Add ("Ennemy0", 5f);
				Add ("Ennemy0", 0.5f);
				Add ("Ennemy0", 0.5f); // Vague 2
				Add ("Ennemy0", 5f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				break;

			case 3:
				Add ("Ennemy0", 5f); // Vague 3
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f); // String dans ressource et temps qui le sépare du mob précédent.
				Add ("Ennemy0", 5f);
				Add ("Ennemy0", 0.1f); // Vague 3
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 5f); // String dans ressource et temps qui le sépare du mob précédent.
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f); // Vague 3
				Add ("Ennemy0", 5f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f); // String dans ressource et temps qui le sépare du mob précédent.
				Add ("Ennemy0", 0.1f);
				break;
			case 2:
				Add ("Ennemy0", 5f); // Vague 4
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f); // String dans ressource et temps qui le sépare du mob précédent.
				Add ("Ennemy0", 5f);
				Add ("Ennemy0", 0.1f); // Vague 4
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 5f); // String dans ressource et temps qui le sépare du mob précédent.
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f); // Vague 4
				Add ("Ennemy0", 5f);
				Add ("Ennemy0", 0.1f); // String dans ressource et temps qui le sépare du mob précédent.
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				break;

			case 1:
				Add ("Ennemy0", 5f); // Vague 5
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f); // Vague 5
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f); // Vague 5
				Add ("Ennemy0", 0.1f); // String dans ressource et temps qui le sépare du mob précédent.
				Add ("Ennemy0", 0.1f);
				Add ("Boss1",0.1f);
                        
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                ////////////////////////////////////////////// MAP 2
                switch (waveRemaining)
                {
                    case 5:
                        Add("Ennemy0", 5f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 2f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.1f);// Vague 1
                        Add("Ennemy0", 5f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 1f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 5f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 1f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 5f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.5f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.2f);
                        break;
                    case 4:
                        Add("Ennemy0", 5f); // Vague 2
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 5f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.5f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.5f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.5f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.5f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.2f);
                        break;
                    case 3:
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.1f);
						Add("Ennemy0", 0.2f);
				Add("MOB_Sapeur", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.1f);
				Add("MOB_Sapeur", 0.1f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 0.1f);
				Add("MOB_Sapeur", 0.2f);
				Add("Ennemy0", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.1f);
				Add("MOB_Sapeur", 0.2f);
				Add("Ennemy0", 0.5f);
				Add("MOB_Sapeur", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 0.2f);
				Add("MOB_Sapeur", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 3f);
				Add("MOB_Sapeur", 0.2f);
				Add("MOB_Sapeur", 0.5f);
				Add("MOB_Sapeur", 0.2f);
				Add("MOB_Sapeur", 0.2f);
				Add("Ennemy0", 0.1f);
                        break;

			case 2:
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 0.2f);
				Add("MOB_Sapeur", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 0.1f);
				Add("MOB_Sapeur", 0.1f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 0.1f);
				Add("MOB_Sapeur", 0.2f);
				Add("Ennemy0", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.1f);
				Add("MOB_Sapeur", 0.2f);
				Add("MOB_Sapeur", 0.2f);
				Add("MOB_Sapeur", 0.2f);
				Add("Ennemy0", 0.5f);
				Add("MOB_Sapeur", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 0.2f);
				Add("MOB_Sapeur", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 3f);
				Add("MOB_Sapeur", 0.2f);
				Add("MOB_Sapeur", 0.5f);
				Add("MOB_Sapeur", 0.2f);
				Add("MOB_Sapeur", 0.2f);
				Add("MOB_Sapeur", 0.2f);
				Add("MOB_Sapeur", 0.2f);
				Add("MOB_Sapeur", 0.2f);
				Add("MOB_Sapeur", 0.2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				break;

			case 1:
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.2f);
				Add ("MOB_Sapeur", 0.5f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 2f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("MOB_Sapeur", 0.1f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 2f);
				Add ("Ennemy0", 0.5f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 2f);
				Add ("Ennemy0", 0.5f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 0.1f);
				Add("Ennemy0", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Boss1", 2f);
				Add ("MOB_Sapeur", 0.2f);
				Add ("Ennemy0", 0.5f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 2f);
				Add ("Ennemy0", 0.5f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 2f);
				Add ("Ennemy0", 0.1f);
				Add ("MOB_Sapeur", 0.2f);
				Add ("MOB_Sapeur", 0.2f);
				Add("Ennemy0", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add ("MOB_Sapeur", 0.2f);
				Add ("Boss1", 2f);
				Add ("MOB_Sapeur", 0.2f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 2f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.2f);
				Add ("MOB_Sapeur", 0.5f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 2f);
				Add ("Ennemy0", 0.2f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 0.1f);
				Add ("Ennemy0", 3f);
				Add("Ennemy0", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add ("Boss2", 2f);
				Add("Ennemy0", 0.1f);
				Add("Ennemy0", 2f);
				Add("Ennemy0", 0.5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				break;
                    default:
                        break;
                }
                break;
            case 3:
                //////////////////////////////////////////// MAP 3
                switch (waveRemaining)
                {
                    case 4:
                        Add("Ennemy0", 5f); // Vague 1
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 5f);
						Add("Ennemy0", 0.5f);
						Add("Ennemy0", 5f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.5f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.5f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.2f);
                        break;
                    case 3:
						Add("Ennemy0", 0.5f);
						Add("Ennemy0", 0.2f);
						Add("Ennemy0", 0.2f);
                        Add("Assassin", 5f); // Vague 2
						Add("Assassin", 0.1f);
                        Add("Ennemy0", 5f);
					Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
						Add("Ennemy0", 5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
						Add("Boss1", 5f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Assassin", 5f); // Vague 2
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Ennemy0", 10f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Boss1", 5f);


                        break;
                    case 2:
				Add("Ennemy0", 1f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Boss1", 5f);
				Add("Ennemy0", 1f);
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Boss1", 5f);
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Boss2", 5f);
                        break;
                    case 1:
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Assassin", 0.1f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Ennemy0", 0.2f);
				Add("Boss3", 5f);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        waveRemaining-=1;
		Debug.Log (waveRemaining);
        return queue;
    }

    // Use this for initialization
    void Start () {
        Map = PlayerPrefs.GetInt("Histoire");
        switch (Map)
        {
            case 1:
                //Map1
                waveRemaining = 5;
                break;
            case 2:
                //Map2
                waveRemaining = 5;
                break;
            case 3:
                //Map3
                waveRemaining = 4;
                break;
            default:
                break;
        }
        level = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Add(string ennemy, float waitTime)
    {
        queue.Enqueue(new KeyValuePair<string, float>(ennemy, waitTime));
    }
}
