using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cin1_ST : MonoBehaviour {

	float timer;
	public UILabel label;
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
		timer = 0;
		i = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if (un && timer > 44 && timer < 49)
		{
			label.text = Localization.Get ("Cin1_"+i);
			un = false;
			i += 1;
		}
		if (deux && timer > 50 && timer < 54)
		{
			label.text = Localization.Get ("Cin1_" + i);
			deux = false;
			i += 1;
		}
		if (trois && timer > 54 && timer < 57)
		{
			label.text = Localization.Get ("Cin1_" + i);
			trois = false;
			i += 1;
		}
		if (quatre && timer > 57 && timer < 58)
		{
			label.text = Localization.Get ("Cin1_" + i);
			quatre = false;
			i += 1;
		}
		if (cinq && timer > 58 && timer < 60)
		{
			label.text = Localization.Get ("Cin1_" + i);
			cinq = false;
			i += 1;
		}
		if (six && timer > 61 && timer < 64)
		{
			label.text = Localization.Get ("Cin1_" + i);
			six = false;
			i += 1;
		}
		if (sept && timer > 64 && timer < 66)
		{
			label.text = Localization.Get ("Cin1_" + i);
			sept = false;
			i += 1;
		}

		if (huit && timer > 66 && timer < 69)
		{
			label.text = Localization.Get ("Cin1_" + i);
			huit = false;
			i += 1;
		}
		if (neuf && timer > 69 && timer < 70)
		{
			label.text = Localization.Get ("Cin1_" + i);
			neuf = false;
			i += 1;
		}

	}
}
