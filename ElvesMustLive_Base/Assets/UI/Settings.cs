using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    public UIScrollBar son;
    public UIControl UI;

    public void French()
    {
        Localization.language = "Français";
    }

    public void English()
    {
        Localization.language = "English";
    }

    public void Sound(float value)
    {
        AudioListener.volume = value;
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
        if (UI != null)
        {
            UI.PauseWindow.SetActive(true);
            //UI.mouseControl.Active(false);
        }
        else
        {
            GameObject.Find("Launcher").GetComponent<Launcher>().ActiveCol(GameObject.Find("Launcher").GetComponent<Launcher>().controls, true);
        }
    }

    public void SetKey()
    {
        PlayerPrefs.SetInt("Control", 0); // 0 = keyboard
        if (UI != null)
        {
            UI.home.useController = false;
            UI.mouseControl.Active(false);
        }
    }

    public void SetCont()
    {
        PlayerPrefs.SetInt("Control", 1); // 1 = xbox controller
        if (UI != null)
        {
            UI.home.useController = true;
            UI.mouseControl.Active(true);
        }
    }

    // Use this for initialization
    void Start () {
        son.value = AudioListener.volume;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
