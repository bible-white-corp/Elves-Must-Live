using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickTurret : MonoBehaviour {

    public PlayerControl home;

    public void CallChangeTurret(string name)
    {
        home.raycast.ChangeTurret(name);
    }
}
