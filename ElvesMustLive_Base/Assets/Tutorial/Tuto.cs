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
                label.text = Localization.Get("tuto_" + i);
                i++;
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                }
                break;
            case 3:
                if (!game.ennemyInMap)
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 4:

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 5:

                if (Input.GetKeyDown(KeyCode.B))
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 6:
                if (Input.GetKeyDown(KeyCode.B) && game.masterClient.raycast.placable && game.masterClient.raycast.NearGround)
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });

                }
                break;
            case 7:
                if (GameObject.FindGameObjectWithTag("Shootable") == null)
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 8:
                if (Input.GetKeyDown(KeyCode.V))
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 9:
                if (game.masterClient.raycast.AvailableTurrets.Count >= 2)
                {
                    var turret = game.masterClient.raycast.AvailableTurrets.Find(x => !x.Key.Contains("Cannon"));
                    label.text = "[00bfff]" + Localization.Get(turret.Key.Split('_')[0]) + "[-] ? " + Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 10:
                if (Input.GetKeyDown(KeyCode.B))
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 11:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                    game.masterClient.gold = 200;
                }
                break;
            case 12:
                if (game.masterClient.gold < 200)
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });
                    PhotonNetwork.InstantiateSceneObject("Ennemy0", gameObject.transform.position, Quaternion.identity, 0, new object[] { });

                }
                break;
            case 13:
                if (!game.ennemyInMap)
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 14:
                if (game.masterClient.MyUI.upgrade.gameObject.GetActive())
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 15:
                if (game.masterClient.raycast.AvailableTurrets.Exists(x => x.Key.Contains("1")))
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 16:
                if (game.masterClient.MyUI.boutikScript.WeaponsSel)
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 17:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 18:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 19:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    label.text = Localization.Get("tuto_" + i);
                    i++;
                }
                break;
            case 20:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    label.text = "";
                    i++;
                }
                break;
            default:
                break;
        }

	}

    
}
