﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boutique : MonoBehaviour {

    public bool TurretsSel = true;
    public bool WeaponsSel = false;

    public GameObject WeaponList;
    public GameObject TurretList;

    public UILabel selected;
    public UILabel log;

    GameObject currentTurret = null;
    GameObject currentWeapon = null;

    public PlayerControl home;

    public void SelectTurret(GameObject obj)
    {
        currentTurret = obj;
        string str = obj.transform.GetChild(0).GetComponent<UILabel>().text;
        int price = int.Parse(obj.transform.GetChild(2).GetComponent<UILabel>().text.Split(' ')[0]);
        selected.text = str + " : " + price + " Gold";
    }
    public void SelectWeapon(GameObject obj)
    {
        currentWeapon = obj;
        string str = obj.transform.GetChild(0).GetComponent<UILabel>().text;
        int price = int.Parse(obj.transform.GetChild(2).GetComponent<UILabel>().text.Split(' ')[0]);
        selected.text = str + " : " + price + " Gold";
    }

    public void BuySelected()
    {
        if (TurretsSel && currentTurret != null)
        {
            home.raycast.AddTurret(currentTurret.transform.GetChild(0).GetComponent<UILabel>().text);
            TurretList.GetComponent<UIGrid>().RemoveChild(currentTurret.transform.GetSiblingIndex());
            Destroy(currentTurret);
            TurretList.GetComponent<UIGrid>().Reposition();
            currentTurret = null;
            selected.text = "Select a object";
            ShowTurrets();
        }
        else if (WeaponsSel && currentWeapon != null)
        {
            home.weapons.AddWeapon(currentWeapon.transform.GetChild(0).GetComponent<UILabel>().text);
            WeaponList.GetComponent<UIGrid>().RemoveChild(currentWeapon.transform.GetSiblingIndex());
            Destroy(currentWeapon);
            WeaponList.GetComponent<UIGrid>().Reposition();
            currentWeapon = null;
            selected.text = "Select a object";
            ShowWeapons();
        }
        else
        {
            log.text = "Nothing selected";
        }
    }

    public void ShowTurrets()
    {
        if (currentTurret != null)
        {
            GameObject obj = currentTurret;
            string str = obj.transform.GetChild(0).GetComponent<UILabel>().text;
            int price = int.Parse(obj.transform.GetChild(2).GetComponent<UILabel>().text.Split(' ')[0]);
            selected.text = str + " : " + price + " Gold";
        }
        else
        {
            selected.text = "Select a Turret";
        }
        WeaponsSel = false;
        TurretsSel = true;
        WeaponList.SetActive(false);
        TurretList.SetActive(false);
        TurretList.SetActive(true);
    }

    public void ShowWeapons()
    {
        if (currentWeapon != null)
        {
            GameObject obj = currentWeapon;
            string str = obj.transform.GetChild(0).GetComponent<UILabel>().text;
            int price = int.Parse(obj.transform.GetChild(2).GetComponent<UILabel>().text.Split(' ')[0]);
            selected.text = str + " : " + price + " Gold";
        }
        else
        {
            selected.text = "Select a Weapon";
        }
        WeaponsSel = true;
        TurretsSel = false;
        TurretList.SetActive(false);
        WeaponList.SetActive(false);
        WeaponList.SetActive(true);

    }
}