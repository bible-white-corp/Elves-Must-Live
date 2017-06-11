using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cin2_ST : MonoBehaviour {

	float timer;
	public UILabel label;
	int i;
	bool un = true;
	bool deux=true;
	bool trois=true;
	bool quatre=true;

	void Start () 
	{
		timer = 0;
		i = 1;
	}
		
	void Update () 
	{
		timer += Time.deltaTime;
		if (un && timer > 21 && timer < 24)
		{
			label.text = Localization.Get ("Cin2_"+i);
			un = false;
			i += 1;
		}
		if (deux && timer > 25 && timer < 29)
		{
			label.text = Localization.Get ("Cin2_" + i);
			deux = false;
			i += 1;
		}
		if (trois && timer > 30&& timer < 32)
		{
			label.text = Localization.Get ("Cin2_" + i);
			trois = false;
			i += 1;
		}
		if (quatre && timer > 34 && timer < 35)
		{
			label.text = Localization.Get ("Cin2_" + i);
			quatre = false;
			i += 1;
		}
	}
}
