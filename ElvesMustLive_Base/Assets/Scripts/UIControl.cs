using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour {

    public GameObject UITurret;
    public UILabel UIGold;
    public UILabel UIModeLevel;
    public UILabel UICount;
    public UISlider UIHealth;
    public OnClickTurret scriptClick;
    public GameObject tchat;
    public Boutique boutikScript;

    Game game;
    public PlayerControl home;

    public bool dead;
    public UILabel DeadText;
    public GameObject Respawn;


    public Transform TurretList;
    public int pixelAlignTurret;

    // Use this for initialization
    void Start () {
        pixelAlignTurret = 0;
        game = GameObject.Find("GameManager").GetComponent<Game>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnGUI()
    {
        if (!dead)
        {
            UIHealth.value = home.hp.health / home.hp.maxhealth;
            UIGold.text = home.gold + " Golds";
            UICount.text = game.wave.currentWave.Count + " restants";
            UIModeLevel.text = "Level " + game.wave.mode.level;
        }
    }


    //Oui, le script de respawn est dans le script de l'UI et oui très sale, et oui c'est full bidouillage :)

    public void DeadMode()
    {
        UICount.gameObject.SetActive(false);
        UIGold.gameObject.SetActive(false);
        UIHealth.gameObject.SetActive(false);
        UITurret.gameObject.SetActive(false);
        
        dead = true;
        DeadText.enabled = true;
        Respawn.SetActive(true);
    }

    public void Revive()
    {
        UICount.gameObject.SetActive(true);
        UIGold.gameObject.SetActive(true);
        UIHealth.gameObject.SetActive(true);
        UITurret.gameObject.SetActive(false);

        dead = false;
        DeadText.enabled = false;
        Respawn.SetActive(false);

        home.hp.Respawn();
    }

    public void AddTurret(string turret, int price)
    {
        bool state = UITurret.GetActive();
        UITurret.SetActive(true);

        GameObject obj = (GameObject)Instantiate(Resources.Load("UI/TurretBase"), TurretList);
        Transform tmp = obj.transform;
        tmp.position = new Vector3(pixelAlignTurret, tmp.transform.position.y, tmp.transform.position.z);
        tmp.GetChild(0).GetComponent<UILabel>().text = turret;
        tmp.GetChild(1).GetComponent<UILabel>().text = "New !";
        tmp.GetChild(2).GetComponent<UILabel>().text = price + " Golds";
        tmp.GetChild(4).GetComponent<UISprite>().spriteName = turret;
        tmp.GetComponent<OnClickTurret>().home = home;
        TurretList.GetComponent<UIGrid>().AddChild(tmp);
        TurretList.GetComponent<UIGrid>().Reposition();

        UITurret.SetActive(state);
    }

    public static UIControl SetUI(string mode, PlayerControl home)
    {
        UIControl UI;
        if (mode == "Left")
        {
            UI = ((GameObject)Instantiate(Resources.Load("UI/UIMulti"))).GetComponent<UIControl>();
            UI.GetComponentInChildren<Camera>().rect = new Rect(0, 0, 0.5f, 1);
        }
        else if (mode == "Right")
        {
            UI = ((GameObject)Instantiate(Resources.Load("UI/UIMulti"))).GetComponent<UIControl>();
            UI.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0, 1, 1);
        }
        else
        {
            UI = ((GameObject)Instantiate(Resources.Load("UI/UISinglePlayer"))).GetComponent<UIControl>();
        }

        UI.home = home;
        UI.scriptClick.home = home;
        UI.boutikScript.home = home;
        UI.UITurret.SetActive(false);
        return UI;
    }

    public static UIControl SetUI(string mode)
    {
        UIControl UI = ((GameObject)Instantiate(Resources.Load("UI" + mode))).GetComponent<UIControl>();
        return UI;
    }
}
