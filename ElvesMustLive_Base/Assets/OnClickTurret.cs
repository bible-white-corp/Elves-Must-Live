using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickTurret : MonoBehaviour {

    public PlayerControl home;
    public void CallChangeTurret(string name)
    {
        int i = 0;
        while (i < home.raycast.AvailableTurrets.Count)
        {
            if (home.raycast.AvailableTurrets[i].Key == name)
            {
                home.raycast.curretTurret = i;
                home.raycast.ChangeTurret(home.raycast.AvailableTurrets[i]);
                return;
            }
            i++;
        }
    }
}
