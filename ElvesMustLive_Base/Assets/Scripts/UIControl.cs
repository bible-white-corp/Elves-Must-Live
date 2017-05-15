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
    public GameObject PauseWindow;

    public Settings settrings;
    public UpgradeWindow upgrade;
    public BoutikOrc boutikOrc;

    public Game game;
    public PlayerControl home;

    public bool dead;
    public UILabel DeadText;
    public UILabel Info;
    public UILabel Story;
    public GameObject Respawn;

    public MiniMapScript mapScript;

    public Transform TurretList;
    public int pixelAlignTurret;

    public float timer;
    public float StoryTxtDuration = 5f;

    Queue<string> StoryTampon = new Queue<string>();
         
    // Use this for initialization
    void Start () {
        pixelAlignTurret = 0;
        game = GameObject.Find("GameManager").GetComponent<Game>();

        upgrade.enabled = true;

        foreach (Transform child in upgrade.turrets)
        {
            child.GetComponent<Collider>().enabled = false;
            child.GetComponent<UIButton>().state = UIButtonColor.State.Disabled;
        }
        //upgrade.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Story.enabled)
        {
            timer += Time.deltaTime;
            if (timer > StoryTxtDuration)
            {
                if (StoryTampon.Count >  0)
                {
                    timer = 0f;
                    Story.text = StoryTampon.Dequeue();
                }
                else
                {
                    Story.enabled = false;
                }
            }
        }
	}

    public void SetStory(string key)
    {
        
        if (Story.enabled)
        {
            StoryTampon.Enqueue(key);
        }
        else
        {
            timer = 0;
            Story.text = Localization.Get(key);
            Story.enabled = true;
        }

    }

    private void OnGUI()
    {
        if (!dead)
        {
            UIHealth.value = home.hp.health / home.hp.maxhealth;
            UIGold.text = home.gold + " " + Localization.Get("gold_start");
			UICount.text = game.wave.ennemiesleft.ToString() + " " + Localization.Get("left");
            UIModeLevel.text = Localization.Get("Level") + game.wave.mode.level;
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
        tmp.GetChild(0).GetComponent<UILocalize>().key = turret;
        tmp.GetChild(0).GetComponent<UILabel>().text = Localization.Get(turret);
        tmp.GetChild(1).GetComponent<UILocalize>().key = "new";
        tmp.GetChild(1).GetComponent<UILabel>().text = Localization.Get("new");
        tmp.GetChild(2).GetComponent<UILabel>().text = price + " " + Localization.Get("gold_start");
        tmp.GetChild(4).GetComponent<UISprite>().spriteName = turret;
        tmp.GetComponent<OnClickTurret>().home = home;
        tmp.name = turret;
        tmp.GetComponent<OnClickTurret>().TurretCode = turret;
        TurretList.GetComponent<UIGrid>().AddChild(tmp);
        TurretList.GetComponent<UIGrid>().Reposition();

        UITurret.SetActive(state);
    }

    public void RemoveTurret(string old)
    {
        bool state = UITurret.GetActive();
        UITurret.SetActive(true);

        Transform oldTurret = TurretList.transform.Find(old);
        TurretList.GetComponent<UIGrid>().RemoveChild(oldTurret);
        Destroy(oldTurret);
        TurretList.GetComponent<UIGrid>().Reposition();

        UITurret.SetActive(state);
    }

    public void QuitGame()
    {
        game.GetComponent<NetworkController>().LeaveRoom();
    }

    public void Resume()
    {
        PauseWindow.SetActive(false);
        home.MenuActif = false;
        home.PauseActif = false;
    }

    public void OpenSettings()
    {
        settrings.gameObject.SetActive(true);
        PauseWindow.SetActive(false);
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
            UI.transform.position = new Vector3(-35, UI.transform.position.y, UI.transform.position.z);
        }
        else
        {
            UI = ((GameObject)Instantiate(Resources.Load("UI/UISinglePlayer"))).GetComponent<UIControl>();
        }

        UI.home = home;
        UI.scriptClick.home = home;
        UI.boutikScript.home = home;
        UI.boutikOrc.home = home;
        UI.UITurret.SetActive(false);
        UI.mapScript.home = home;
        return UI;
    }

    public static UIControl SetUI(string mode)
    {
        UIControl UI = ((GameObject)Instantiate(Resources.Load("UI" + mode))).GetComponent<UIControl>();
        return UI;
    }
    
}
