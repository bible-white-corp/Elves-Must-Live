using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boutique : MonoBehaviour {

    public bool TurretsSel = true;
    public bool WeaponsSel = false;

    public GameObject WeaponList;
    public GameObject TurretList;

    public UILabel selected;
    public UILabel description;
    public UILabel log;

    GameObject currentTurret = null;
    GameObject currentWeapon = null;

    public PlayerControl home;

    public void SelectTurret(GameObject obj)
    {
        currentTurret = obj;
        string str = obj.transform.GetChild(0).GetComponent<UILabel>().text;
        int price = int.Parse(obj.transform.GetChild(2).GetComponent<UILabel>().text.Split(' ')[0]);
        description.text = obj.transform.GetChild(5).GetComponent<UILabel>().text;
        selected.text = str + " : " + price + " Gold";
    }
    public void SelectWeapon(GameObject obj)
    {
        currentWeapon = obj;
        string str = obj.transform.GetChild(0).GetComponent<UILabel>().text;
        int price = int.Parse(obj.transform.GetChild(2).GetComponent<UILabel>().text.Split(' ')[0]);
        description.text = "Je ne pense pas qu'un description soit nécéssaire... Ces armes ou ces arcs sont dévastateurs";
        selected.text = str + " : " + price + " Gold";
    }

    public void BuySelected()
    {
        if (TurretsSel && currentTurret != null)
        {
            int price = int.Parse(currentTurret.transform.GetChild(2).GetComponent<UILabel>().text.Split(' ')[0]);
            string str = currentTurret.transform.GetChild(0).GetComponent<UILabel>().text;
            if (price > home.gold)
            {
                log.text = "No enought money !";
                return;
            }
            else
            {
                home.gold -= price;
                log.text = str + " bought";
                description.text = "Sélectionner un élément pour obtenir sa description.";
            }
            home.raycast.AddTurret(currentTurret.transform.GetChild(0).GetComponent<UILabel>().text, 0);
            TurretList.GetComponent<UIGrid>().RemoveChild(currentTurret.transform);
            Destroy(currentTurret);
            TurretList.GetComponent<UIGrid>().Reposition();
            currentTurret = null;
            selected.text = "Select a object";
            ShowTurrets();
        }
        else if (WeaponsSel && currentWeapon != null)
        {
            int price = int.Parse(currentWeapon.transform.GetChild(2).GetComponent<UILabel>().text.Split(' ')[0]);
            string str = currentWeapon.transform.GetChild(0).GetComponent<UILabel>().text;
            if (price > home.gold)
            {
                log.text = "No enought money !";
                return;
            }
            else
            {
                home.gold -= price;
                log.text = str + " bought";
                description.text = "Sélectionner un élément pour obtenir sa description.";
            }
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
        WeaponsSel = false;
        TurretsSel = true;
        WeaponList.SetActive(false);
        TurretList.SetActive(false);
        TurretList.SetActive(true);
        if (currentTurret != null)
        {
            SelectTurret(currentTurret);
        }
        else
        {
            selected.text = "Select a Turret";
            description.text = "Sélectionner un élément pour obtenir sa description.";
        }
    }

    public void ShowWeapons()
    {
        WeaponsSel = true;
        TurretsSel = false;
        TurretList.SetActive(false);
        WeaponList.SetActive(false);
        WeaponList.SetActive(true);
        if (currentWeapon != null)
        {
            SelectWeapon(currentWeapon);
        }
        else
        {
            selected.text = "Select a Weapon";
            description.text = "Sélectionner un élément pour obtenir sa description.";
        }
    }
}
