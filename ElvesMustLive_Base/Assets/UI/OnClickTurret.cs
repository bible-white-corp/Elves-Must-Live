using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickTurret : MonoBehaviour {

    public PlayerControl home;
    public string TurretCode;

    public void CallChangeTurret()
    {
        home.raycast.ChangeTurret(TurretCode);
    }
}
