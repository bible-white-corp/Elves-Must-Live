using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cin1_ST : MonoBehaviour {

	public float timer;
	public Text label;
	int i;
	bool un = true;
	bool deux=true;
	bool trois=true;
	bool quatre=true;
	bool cinq=true;
	bool six=true;
	bool sept=true;
	bool huit=true;
	bool neuf=true;
	void Start () 
	{
        label = GetComponent<Text>();
		timer = 0;
		i = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
        label.text = "";
		if (timer > 46 && timer < 49.7)
		{
			label.text = Localization.Get ("Cin1_1");
			un = false;
			i += 1;
		}
		if (timer > 50.2 && timer < 53.5)
		{
			label.text = Localization.Get ("Cin1_2");
			deux = false;
			i += 1;
		}
		if (timer > 53.5 && timer < 57.4)
		{
            label.text = Localization.Get("Cin1_3");
            trois = false;
			i += 1;
		}
		if (timer > 57.4 && timer < 58.5)
		{
            label.text = Localization.Get("Cin1_4");
            quatre = false;
			i += 1;
		}
		if (timer > 58.5 && timer < 60)
		{
            label.text = Localization.Get("Cin1_5");
            cinq = false;
			i += 1;
		}
		if (timer > 61.5 && timer < 64.5)
		{
            label.text = Localization.Get("Cin1_6");
            six = false;
			i += 1;
		}
		if (timer > 64 && timer < 66.5)
		{
            label.text = Localization.Get("Cin1_7");
            sept = false;
			i += 1;
		}

		if (timer > 66.5 && timer < 69.4)
		{
            label.text = Localization.Get("Cin1_8");
            huit = false;
			i += 1;
		}
        if (timer > 69.4 && timer < 70)
        {
            label.text = Localization.Get("Cin1_9");
            neuf = false;
            i += 1;
        }
        if (timer > 70)
        {
            label.text = "";
            neuf = false;
            i += 1;
        }

    }
}
