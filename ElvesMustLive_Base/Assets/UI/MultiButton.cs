using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiButton : MonoBehaviour {

    public UILabel text;
    
	// Use this for initialization
	void Start () {
        Change();
	}

    public void Change()
    {
        if (PlayerPrefs.GetInt("mod") == 1)
        {
            text.text = Localization.Get("multi");
        }
        else
        {
            text.text = Localization.Get("single");
        }
    }
}
