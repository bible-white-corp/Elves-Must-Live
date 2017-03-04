using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadProgress : Photon.MonoBehaviour {

    public Canvas MainCanvas;
    public Canvas LoadCanvas;
    public GameObject DoneText;

    public Texture2D emptyTex;
    public Texture2D fullTex;
    public float barDisplay = 0;
    public float NetworkState = 0;
    public float LoadState = 0;
    Vector2 pos;
    Vector2 pos2;
    Vector2 size;
    Vector2 size2;

    private float velocity = 0;
    private AsyncOperation async = null;

    public bool isLoading;

    private void Start()
    {
        pos = new Vector2(0, 0);    
        size = new Vector2(Screen.width, Screen.height);
        size2 = new Vector2(1000, 400);
        pos2 = new Vector2(Screen.width / 2 - size2.x / 2, Screen.height / 2 - size2.y / 2);
    }
    public void LoadALevel(string levelName)
    {
        Debug.Log("called");
        PhotonNetwork.PrepareLoadLevel(levelName);

        if (Application.HasProLicense()) //C'est beaucoup plus joli si vous crackez Unity les gars.
        {
            async = SceneManager.LoadSceneAsync(levelName);
            async.allowSceneActivation = false;
        }
        else
        {
            LoadState = 1;
            barDisplay = 1;
            SceneManager.LoadScene(levelName);
        }
        Set(true);
        //yield return async;
    }

    public void Set(bool b)
    {
        if (b)
        {
            MainCanvas.enabled = false;
            LoadCanvas.enabled = true;
            isLoading = true;
        }
        else
        {
            MainCanvas.enabled = true;
            LoadCanvas.enabled = false;
            isLoading = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (async.progress == 0.9f)
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
                DoneText.SetActive(true);
            }
            else
            {
                barDisplay = Mathf.SmoothDamp(barDisplay, (NetworkState + LoadState) / 2, ref velocity, 0.3f);
            }
            Debug.Log(barDisplay);

            //draw the background:
            GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

            //draw the filled-in part:
            GUI.BeginGroup(new Rect(pos2.x, pos2.y, size2.x * barDisplay, size2.y));
            GUI.Box(new Rect(0, 0, size2.x, size2.y), fullTex);
            GUI.EndGroup();
            GUI.EndGroup();
        }
    }

}
