using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWindow : MonoBehaviour {

    public UIControl ui;
    public Transform turrets;

    Transform currentTurret;

	// Use this for initialization
	void Start () {
        foreach (Transform child in turrets)
        {
            child.GetComponent<Collider>().enabled = false;
            child.GetComponent<UIButton>().state = UIButtonColor.State.Disabled;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
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
        ui.home.raycast.UpgradeTurret(currentTurret.name);
    }

}
