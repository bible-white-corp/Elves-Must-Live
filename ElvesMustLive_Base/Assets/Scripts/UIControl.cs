using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour {

    public GameObject UITurret;
    public UILabel UIGold;
    public UILabel UICount;
    public UISlider UIHealth;
    public OnClickTurret scriptClick;
    public GameObject tchat;

    Game game;
    public PlayerControl home;

    public bool dead;
    public UILabel DeadText;
    public GameObject Respawn;
    object[] respawnData;
    GameObject camera;

    // Use this for initialization
    void Start () {
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
            UICount.text = game.wave.count + " restants";
        }
    }


    //Oui, le script de respawn est dans le script de l'UI et oui très sale, et oui c'est full bidouillage :)

    public void DeadMode(object[] data, GameObject camera)
    {
        this.camera = camera;   //Pour virer la camera au click
        Destroy(UICount.gameObject);
        Destroy(UIGold.gameObject);
        Destroy(UIHealth.gameObject);
        Destroy(UITurret.gameObject);

        respawnData = data;
        dead = true;
        DeadText.enabled = true;
        Respawn.SetActive(true);
    }

    public void Revive()
    {
        PhotonNetwork.Instantiate("Perso", game.transform.position, Quaternion.identity, 0, respawnData);
        Destroy(camera);
        Destroy(this.gameObject);// On destroy l'UI qui va être recréé lors de l'instantiation du player
    }



    public static UIControl SetUI(string mode, PlayerControl home)
    {
        UIControl UI = ((GameObject)Instantiate(Resources.Load("UI" + mode))).GetComponent<UIControl>();
        UI.home = home;
        UI.scriptClick.home = home;
        UI.UITurret.SetActive(false);
        return UI;
    }

    public static UIControl SetUI(string mode)
    {
        UIControl UI = ((GameObject)Instantiate(Resources.Load("UI" + mode))).GetComponent<UIControl>();
        return UI;
    }
}
