using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadProgress : Photon.MonoBehaviour {

    public UIPanel MainCanvas;
    public UILabel DoneText;
    public UISlider slid;

    public float barDisplay = 0;
    public float NetworkState = 0;
    public float LoadState = 0;

    private float velocity = 0;
    private AsyncOperation async = null;

    public bool isLoading;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Cin") && PlayerPrefs.GetInt("Cin") == 1)
        {
            PlayerPrefs.SetInt("Cin", 0);
            GetComponent<Launcher>().LevelName = "Map/Map 1";
            NetworkState = 1;
            LoadALevel("Map/Map 1");
        }
    }
    public void LoadALevel(string levelName)
    {
        if (levelName == "Map/Map 1-")
        {
            PlayerPrefs.SetInt("Cin", 1);
            SceneManager.LoadScene("Cin1");
            return;
        }
        else
        {
            PlayerPrefs.SetInt("Cin", 0);
        }

        PhotonNetwork.PrepareLoadLevel(levelName);

        async = SceneManager.LoadSceneAsync(levelName);
        async.allowSceneActivation = false;

        Set(true);
        //yield return async;
    }

    public void Set(bool b)
    {
        if (b)
        {
            MainCanvas.enabled = false;

            isLoading = true;
        }
        else
        {
            MainCanvas.enabled = true;

            isLoading = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (async != null && async.progress == 0.9f)
            {
                Debug.Log("Launch");
                async.allowSceneActivation = true;
            }
        }
    }

    void OnGUI()
    {
        if (async != null)
        {
            LoadState = async.progress;
        }
        if (isLoading == true)
        {
            if (async != null && async.progress == 0.9f) //Full loaded
            {
                barDisplay = Mathf.SmoothDamp(barDisplay, 1, ref velocity, 0.3f);
                slid.value = 1 - barDisplay;
                DoneText.enabled = true;
            }
            else
            {
                barDisplay = Mathf.SmoothDamp(barDisplay, (NetworkState + LoadState) / 2, ref velocity, 0.3f);
                slid.value = 1 - barDisplay;
            }

        }
    }

}
