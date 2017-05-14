﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWindow : MonoBehaviour {

    public UIControl ui;
    public Transform turrets;
    Transform currentTurret;
    public UILabel lvl;
    public UILocalize labelName;

    public GameObject Sword;
    public UIPopupList swords;
    public string currentSword = "Nope";
    public GameObject Arc;
    public UIPopupList arcs;
    public string currentArc = "Nope";
    public GameObject Spear;
    public UIPopupList spears;
    public string currentSpear = "Nope";

    public bool weaponActive;

    public List<string> buyWeapons;
    // Use this for initialization
    
    void Start () {
        /*
        foreach (Transform child in turrets)
        {
            child.GetComponent<Collider>().enabled = false;
            child.GetComponent<UIButton>().state = UIButtonColor.State.Disabled;
        }*/
        buyWeapons = new List<string>();
        buyWeapons.Add("Sword1");
        buyWeapons.Add("Spear1");
        buyWeapons.Add("Arc1");
        weaponActive = false;
        currentSword = "Nope";
        currentSpear = "Nope";
        currentArc = "Nope";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void Unlock(string name)
    {
        Transform tmp = turrets.transform.Find(name);
        tmp.GetComponent<Collider>().enabled = true;
        tmp.GetComponent<UIButton>().state = UIButtonColor.State.Normal;
    }

    public void OnClick(Transform name)
    {
        currentTurret = name;
        labelName.key = name.name;
        labelName.GetComponent<UILabel>().text = Localization.Get(labelName.key);
        lvl.text = ui.home.raycast.GetLevel(name.name).ToString();
        if (int.Parse(lvl.text) == 2)
        {
            lvl.text = "Max";
            currentTurret = null;
        }
        if (name.name.Contains("Rocket") && int.Parse(lvl.text) == 1)
        {
            lvl.text = "Max";
            currentTurret = null;
        }
        switch (name.name)
        {
            case "Cannon":

                return;
            case "Hammer":

                return;
            case "CrossBow":

                return;
            case "Cristal":

                return;
            case "Projector":

                return;
            case "Rocket":

                return;
            case "Regen":

                return;
            default:
                Debug.LogError("No turret nammed '" + name.name + "'");
                return; 
        }
    }

    public void Upgrade()
    {
        if (currentTurret == null)
        {
            return;
        }
        ui.home.raycast.UpgradeTurret(currentTurret.name);
        OnClick(currentTurret);     
    }
    //////////////////////////////////// WEAPONS

    public void SwitchToWeapons()
    {

        Sword.gameObject.SetActive(currentSword != "Nope");
        Spear.gameObject.SetActive(currentSpear != "Nope");
        Arc.gameObject.SetActive(currentArc != "Nope");

        weaponActive = true;
        foreach (var item in ui.home.weapons.availableWeapon)
        {
            if (item.name.Contains("Sword"))
            {
                Sword.gameObject.SetActive(true);
                swords.value = item.name;
                currentSword = item.name;
                Sword.transform.GetChild(0).GetComponent<UISprite>().spriteName = currentSword.ToLower();
                Sword.transform.GetChild(3).GetChild(0).GetComponent<UILabel>().text = "Equiped";
            }
            if (item.name.Contains("Spear"))
            {
                Spear.gameObject.SetActive(true);
                spears.value = item.name;
                currentSpear = item.name;
                Spear.transform.GetChild(0).GetComponent<UISprite>().spriteName = currentSpear.ToLower();
                Spear.transform.GetChild(3).GetChild(0).GetComponent<UILabel>().text = "Equiped";
            }
            if (item.name.Contains("Arc"))
            {
                Arc.gameObject.SetActive(true);
                arcs.value = item.name;
                currentArc = item.name;
                Arc.transform.GetChild(0).GetComponent<UISprite>().spriteName = currentArc.ToLower();
                Arc.transform.GetChild(3).GetChild(0).GetComponent<UILabel>().text = "Equiped";
            }

        }
    }

    public void OnSelect(string type)
    {
        string current;
        GameObject go;
        UIPopupList list;
        switch (type)
        {
            case "Sword":
                current = currentSword;
                go = Sword;
                list = swords;
                break;
            case "Spear":
                current = currentSpear;
                go = Spear;
                list = spears;
                break;
            case "Arc":
                current = currentArc;
                go = Arc;
                list = arcs;
                break;
            default:
                return;

        }

        if (!weaponActive || current == "Nope")
        {
            return;
        }
        current = list.value;
        //Debug.Log(current);
        go.transform.GetChild(0).GetComponent<UISprite>().spriteName = current.ToLower();
        
        foreach (var item in buyWeapons)
        {
            Debug.Log(item);
        }
        if (ui.home.weapons.availableWeapon.Exists(x => x.name == current))
        {
            go.transform.GetChild(3).GetChild(0).GetComponent<UILabel>().text = "Equiped";
        }
        else if (buyWeapons.Contains(current))
        {
            go.transform.GetChild(3).GetChild(0).GetComponent<UILabel>().text = Localization.Get("equip");
        }
        else
        {
            go.transform.GetChild(3).GetChild(0).GetComponent<UILabel>().text = Localization.Get("buy");
        }

        switch (type)
        {
            case "Sword":
                currentSword = current;
                break;
            case "Spear":
                currentSpear = current;
                break;
            case "Arc":
                currentArc = current;
                break;
            default:
                return;

        }
    }

    public void BuyOrEquip(string type)
    {
        string current;
        GameObject go;
        UIPopupList list;
        switch (type)
        {
            case "Sword":
                current = currentSword;
                go = Sword;
                list = swords;
                break;
            case "Spear":
                current = currentSpear;
                go = Spear;
                list = spears;
                break;
            case "Arc":
                current = currentArc;
                go = Arc;
                list = arcs;
                break;
            default:
                return;

        }
        if (buyWeapons.Contains(current))
        {
            ui.home.weapons.ChangeWeapon(type, current);
            go.transform.GetChild(3).GetChild(0).GetComponent<UILabel>().text = "Equiped";
        }
        else
        {
            buyWeapons.Add(current);
            go.transform.GetChild(3).GetChild(0).GetComponent<UILabel>().text = Localization.Get("equip");
        }
    }
}
