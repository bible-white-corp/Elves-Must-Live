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
        UI.PauseWindow.SetActive(true);
    }

	// Use this for initialization
	void Start () {
        son.value = AudioListener.volume;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
