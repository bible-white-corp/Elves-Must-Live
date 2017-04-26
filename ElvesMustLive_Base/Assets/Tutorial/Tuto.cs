using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : GameMode {

    public UILabel label;



    int i = 1;

    public override bool HasNextLevel()
    {
        return true;
    }

    public override Queue<KeyValuePair<string, float>> LoadNextLevel()
    {
        return new Queue<KeyValuePair<string, float>>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (i)
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    i++;
                    label.text = "Good ! I will summon a orc. Be ready to attack him with [99ff00]Left Clic[-] " +
                        "\nPress [99ff00]Enter[-] when you are ready !";
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    i++;
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    label.text = "Kill the orc with [99ff00]Left Clic[-] !!"; 
                }
                break;
            case 3:
                
                Debug.Log(GameObject.FindGameObjectWithTag("Shootable"));
                if (GameObject.FindGameObjectWithTag("Shootable") == null)
                {
                    i++;
                    label.text = "Good ! You kill a orc and earn 10 gold !" +
                        "\nPress [99ff00]Enter[-] to continue.";
                }
                break;
            case 4:
                
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    i++;
                    label.text = "You have a 10 of money. You can only buy a Cannon" +
                        "\nPress [99ff00]B[-] to start building a turret.";
                }
                break;
            case 5:
                
                if (Input.GetKeyDown(KeyCode.B))
                {
                    i++;
                    label.text = "Choose a appropriate place to build your cannon (When the cannon is [99ff00]green[-])" +
                        "\nPress [99ff00]B[-] to place the turret.";
                }
                break;
            case 6:
                if (Input.GetKeyDown(KeyCode.B))
                {
                    i++;
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    label.text = "Oups ! 3 orcs are comming ! Dont worry, your cannon will help you !" +
                        "\nAttack the orcs and watch your cannon.";
                }
                break;
            case 7:
                if (GameObject.FindGameObjectWithTag("Shootable") == null)
                {
                    i++;
                    label.text = "Good ! You have a lot of money now ! You can buy other turrets !" +
                        "\nUse the [99ff00]V[-] to buy other turrets and then press [99ff00]B[-] and choose a another turret." +
                        "\nYou're free, summon orc with [99ff00]J[-] to try yourself." +
                        "\nPress [99ff00]Enter[-] to hide this. Press [99ff00]Quit button[-] to leave this level.";
                }
                break;
            case 8:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    i++;
                    label.text = "";
                }
                break;
            default:
                break;
        }

	}

    
}
