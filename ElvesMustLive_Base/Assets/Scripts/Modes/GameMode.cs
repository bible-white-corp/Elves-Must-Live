using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMode : MonoBehaviour {

    public int level;
    public WaveGenerator wave;
    public abstract Queue<KeyValuePair<string, float>> LoadNextLevel();
    public abstract bool HasNextLevel();

}
