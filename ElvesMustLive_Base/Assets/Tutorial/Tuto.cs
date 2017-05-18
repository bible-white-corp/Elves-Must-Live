using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : GameMode {

    public UILabel label;
    public Game game;

    int i;

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
        i = 0;
        game = GameObject.Find("GameManager").GetComponent<Game>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (i)
        {
            case 0:
                i++;
                label.text = "Welcome to the[99ff00]Elves Must Live tutorial[-] !" +
                    "\nYou can move with[99ff00]ZQSD[-]" +
                    "\nPress[99ff00]Enter[-] to continue";
                break;
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
                if (!game.ennemyInMap)
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
                    label.text = "You have a 10 of money. You can only buy a [0000ff]Cannon[-]" +
                        "\nPress [99ff00]B[-] to start building a turret.";
                }
                break;
            case 5:
                
                if (Input.GetKeyDown(KeyCode.B))
                {
                    i++;
                    label.text = "Choose a appropriate place to build your [0000ff]Cannon[-] (When the cannon is [99ff00]green[-])" +
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
                    label.text = "Good ! You have a lot of money now ! You can buy (or upgrade) other turrets !" +
                        "\nPress [99ff00]V[-] to open the [ff0000]Shop[-].";
                }
                break;
            case 8:
                if (Input.GetKeyDown(KeyCode.V))
                {
                    i++;
                    label.text = "Fine. Here you can click on a turret, and select Buy to optain it. Be carrefull, you must have sufficient funds." +
                        "\nChoose a turret and buy it !";
                }
                break;
            case 9:
                if (game.masterClient.raycast.AvailableTurrets.Count >= 2)
                {
                    i++;
                    var turret = game.masterClient.raycast.AvailableTurrets.Find(x => !x.Key.Contains("Cannon"));
                    label.text = "[0000ff]" + Localization.Get(turret.Key.Split('_')[0]) + "[-] ? Perfect ! Leave the shop with [99ff00]Escape[-] and press B to enter in build mode.";
                }
                break;
            case 10:
                if (Input.GetKeyDown(KeyCode.B))
                {
                    i++;
                    label.text = "As you can see, you have now an another turret ! But you don't have enought money... I will give you money."
                        + "\nPress [99ff00]Enter[-]";
                }
                break;
            case 11:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    i++;
                    game.masterClient.gold = 200;
                    label.text = "OMG ! 200 golds... It's a error... Allright, you can now place your turret."
                        + "";
                }
                break;
            case 12:
                if (game.masterClient.gold < 200)
                {
                    i++;
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    label.text = "Shit ! I can't explain without being disturbed ! Kill them !";
                }
                break;
            case 13:
                if (!game.ennemyInMap)
                {
                    i++;
                    label.text = "Phew ! Now upgrade your turrets ! Press [99ff00]V[-] and then click on [ff0000]Upgrade[-].";
                }
                break;
            case 14:
                if (game.masterClient.MyUI.upgrade.gameObject.GetActive())
                {
                    i++;
                    label.text = "Perfect, now click a turret you have, and upgrade it !";
                }
                break;
            case 15:
                if (game.masterClient.raycast.AvailableTurrets.Exists(x => x.Key.Contains("1")))
                {
                    i++;
                    label.text = "Now, click on [ff0000]Weapons[-] on the [ff0000]Shop[-] window.";
                }
                break;
            case 16:
                if (game.masterClient.MyUI.boutikScript.WeaponsSel)
                {
                    i++;
                    label.text = "Here, you can buy weapons. In the game, switch with the mouse scroll wheel." +
                        "\nSame as turrets, you can upgrade weapons on [ff0000]Upgrades[-] window." +
                        "\nPress [99ff00]Enter[-] to continue.";
                }
                break;
            case 17:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    i++;
                    label.text = "It's the end of this tutorial. Now, go out !"+
                        "\nPress [99ff00]Escape[-] to open the Pause window and select Leave !";
                }
                break;
            default:
                break;
        }

	}

    
}
