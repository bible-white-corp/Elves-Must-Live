using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cin2_ST : MonoBehaviour {

	float timer;
	public Text label;
	int i;
	bool un = true;
	bool deux=true;
	bool trois=true;
	bool quatre=true;

	void Start () 
	{
        label = GetComponent<Text>();
		timer = 0;
		i = 1;
	}
		
	void Update () 
	{
        label.text = "";
		timer += Time.deltaTime;
		if (timer > 20.5 && timer < 24.6)
		{
			label.text = Localization.Get ("Cin2_1");
			un = false;
			i += 1;
		}
		if (timer > 24.6 && timer < 29.4)
		{
			label.text = Localization.Get ("Cin2_2");
			deux = false;
			i += 1;
		}
		if (timer > 29.4 && timer < 32.6)
		{
			label.text = Localization.Get ("Cin2_3");
			trois = false;
			i += 1;
		}
        if (timer > 33.5 && timer < 35.9)
        {
            label.text = Localization.Get("Cin2_4");
            quatre = false;
            i += 1;
        }
        if (timer > 36.5)
        {
            label.text = "";
            quatre = false;
            i += 1;
        }
    }
}
