using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutikOrc : MonoBehaviour
{

    public bool TurretsSel = true;

    public GameObject TurretList;

    public UILabel selected;
    public UILabel description;
    public UILabel log;

    GameObject currentTurret = null;

    public PlayerControl home;
    public UIControl ui;

    private void Start()
    {

    }

    public void SelectTurret(GameObject obj)
    {
        currentTurret = obj;
        string str = obj.name;
        int price = int.Parse(obj.transform.GetChild(2).GetComponent<UILabel>().text.Split(' ')[0]);
        description.text = obj.transform.GetChild(5).GetComponent<UILabel>().text;
        selected.text = Localization.Get("cost") + " : " + price + " " + Localization.Get("gold_start");
    }

    public void BuySelected()
    {
        if (TurretsSel && currentTurret != null)
        {
            int price = int.Parse(currentTurret.transform.GetChild(2).GetComponent<UILabel>().text.Split(' ')[0]);
            string str = currentTurret.transform.name;
            if (price > home.gold)
            {
                log.text = Localization.Get("no_money");
                return;
            }
            else
            {
                home.gold -= price;
                log.text = str + Localization.Get("bought");
                description.text = Localization.Get("clickfordes");
            }
            Debug.Log("Ennemie acheté : " + currentTurret.transform.name);
            ////////AJOUT DE LENNEMIE DANS LE MODE VERSUS
            if (PlayerPrefs.GetString("Mode") == "Versus")
            {
                if (PhotonNetwork.isMasterClient)
                {
                    ui.game.GetComponent<Versus>().AddMonster(currentTurret.transform.name, 1);
                }
                else
                {
                    ui.game.GetComponent<Versus>().AddMonster(currentTurret.transform.name, 2);
                }
            }

            //TurretList.GetComponent<UIGrid>().RemoveChild(currentTurret.transform);
            //Destroy(currentTurret);
            //TurretList.GetComponent<UIGrid>().Reposition();
            //currentTurret = null;
            //selected.text = Localization.Get("select_a") + Localization.Get("turrets");
            ShowTurrets();
        }
        else
        {
            log.text = Localization.Get("nothing_sel");
        }
    }

    public void ShowTurrets()
    {
        TurretsSel = true;
        TurretList.SetActive(false);
        TurretList.SetActive(true);
        if (currentTurret != null)
        {
            SelectTurret(currentTurret);
        }
        else
        {
            selected.text = Localization.Get("select_a") + "orc.";
            description.text = Localization.Get("clickfordes");
        }
    }
}
