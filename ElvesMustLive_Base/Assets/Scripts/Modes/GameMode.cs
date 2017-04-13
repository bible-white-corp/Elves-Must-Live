using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMode : MonoBehaviour {

    public abstract Queue<KeyValuePair<string, int>> LoadNextLevel();

}
