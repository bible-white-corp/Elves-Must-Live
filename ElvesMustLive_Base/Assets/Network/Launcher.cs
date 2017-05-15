using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//namespace Com.BibleWhiteCorp.ElvesMustLive
//{
public class Launcher : Photon.PunBehaviour
{
    #region Public Variables

    /// <summary>
    /// The PUN loglevel. 
    /// </summary>
    public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;

    /// <summary>
    /// The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created.
    /// </summary>   
    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    public byte MaxPlayersPerRoom = 4;

    public LoadProgress progress;

    public string LevelName;

    public Settings settings;

    #endregion


    #region Private Variables


    /// <summary>
    /// This client's version number. Users are separated from each other by gameversion (which allows you to make breaking changes).
    /// </summary>
    string _gameVersion = "1";

    /// <summary>
    /// Keep track of the current process. Since connection is asynchronous and is based on several callbacks from Photon, 
    /// we need to keep track of this to properly adjust the behavior when we receive call back by Photon.
    /// Typically this is used for the OnConnectedToMaster() callback.
    /// </summary>
    bool isConnecting;

    public GameObject levelWindow;

    public GameObject historyTab;
    #endregion


    #region MonoBehaviour CallBacks


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
    /// </summary>
    void Awake()
    {
        // #Critical
        // we don't join the lobby. There is no need to join a lobby to get the list of rooms.
        PhotonNetwork.autoJoinLobby = false;


        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.automaticallySyncScene = true;

        // #NotImportant
        // Force LogLevel
        PhotonNetwork.logLevel = Loglevel;
    }

    private void Start()
    {
        //progress.LoadCanvas.enabled = false;
        //progress.MainCanvas.enabled = true;
    }

    public void ShowLevelWindow()
    {
        levelWindow.SetActive(true);
    }

    public void OpenSettings()
    {
        settings.gameObject.SetActive(true);
    }

    public void Quit()
    {
        if (!Application.isEditor)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }

    public void LaunchTuto()
    {
        LevelName = "Tutorial/Level1";
        PlayerPrefs.SetString("Mode", "Tuto");
        Offline();
    }

    public void SetHistory()
    {
        PlayerPrefs.SetString("Mode", "History");
    }

    public void SetEndLess()
    {
        PlayerPrefs.SetString("Mode", "Endless");
    }

    public void LoadHistory()
    {
        if (!PlayerPrefs.HasKey("Histoire"))
        {
            PlayerPrefs.SetInt("Histoire", 0);
        }
        SetHistory();
        switch (PlayerPrefs.GetInt("Histoire"))
        {
            case 0:
                LevelName = "Tutorial/Level1";
                historyTab.transform.GetChild(0).GetComponent<UILabel>().text = Localization.Get("tuto_des");
                historyTab.transform.GetChild(0).GetComponent<UILocalize>().key = "tuto_des";
                historyTab.transform.GetChild(2).GetComponent<UISprite>().spriteName = "tuto";
                PlayerPrefs.SetString("Mode", "Tuto");
                break;
            case 1:
                LevelName = "Map/Map 1";
                historyTab.transform.GetChild(0).GetComponent<UILabel>().text = Localization.Get("niv1_des");
                historyTab.transform.GetChild(0).GetComponent<UILocalize>().key = "niv1_des";
                historyTab.transform.GetChild(2).GetComponent<UISprite>().spriteName = "Map1";
                break;
            case 2:
                LevelName = "Map/MAP 2 multipath/MAP 2";
                historyTab.transform.GetChild(0).GetComponent<UILabel>().text = Localization.Get("niv2_des");
                historyTab.transform.GetChild(0).GetComponent<UILocalize>().key = "niv2_des";
                historyTab.transform.GetChild(2).GetComponent<UISprite>().spriteName = "Map3";
                break;
            case 3:
                LevelName = "Map/map 3/map 3 montagne";
                historyTab.transform.GetChild(0).GetComponent<UILabel>().text = Localization.Get("niv3_des");
                historyTab.transform.GetChild(0).GetComponent<UILocalize>().key = "niv3_des";
                historyTab.transform.GetChild(2).GetComponent<UISprite>().spriteName = "Map2";
                break;
            case 4:
                LevelName = "Map/Map 4/Cave";
                historyTab.transform.GetChild(0).GetComponent<UILabel>().text = Localization.Get("niv4_des");
                historyTab.transform.GetChild(0).GetComponent<UILocalize>().key = "niv4_des";
                historyTab.transform.GetChild(2).GetComponent<UISprite>().spriteName = "Map4";
                break;
            default:
                ResetHistory();
                return;
        }
        
    }

    public void SkipHistory()
    {
        PlayerPrefs.SetInt("Histoire", PlayerPrefs.GetInt("Histoire") +1);
        LoadHistory();
    }

    public void ResetHistory()
    {
        PlayerPrefs.SetInt("Histoire", 0);
        LoadHistory();
    }

    #endregion
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            levelWindow.SetActive(false);
        }
    }

    #region Public Methods

    public void SelectLevel(UIButton MyUIButton, GameObject allMaps)
    {
        foreach (var item in allMaps.GetComponentsInChildren<UIButton>())
        {
            item.SetState(UIButtonColor.State.Normal, false);
            item.GetComponent<Collider>().enabled = true;
        }
        MyUIButton.SetState(UIButtonColor.State.Disabled, false);
        MyUIButton.GetComponent<Collider>().enabled = false;
        LevelName = MyUIButton.gameObject.name;
        Debug.Log("Selected : " + MyUIButton.gameObject.name);
    }

    /// <summary>
    /// Start the connection process. 
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
    public void Connect()
    {
        if (LevelName == "")
        {
            return;
        }
        levelWindow.SetActive(false);
        progress.Set(true);
        progress.NetworkState = 0.25f;
        PhotonNetwork.offlineMode = false;

        // keep track of the will to join a room, because when we come back from the game we will get a callback that we are connected, so we need to know what to do then
        isConnecting = true;

        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.connected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnPhotonRandomJoinFailed() and we'll create one.
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings(_gameVersion);
        }
    }


    #endregion

    #region Photon.PunBehaviour CallBacks


    public override void OnConnectedToMaster()
    {
        Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");
        // we don't want to do anything if we are not attempting to join a room. 
        // this case where isConnecting is false is typically when you lost or quit the game, when this level is loaded, OnConnectedToMaster will be called, in that case
        // we don't want to do anything.
        if (isConnecting)
        {
            // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnPhotonRandomJoinFailed()
            progress.NetworkState = 0.5f;
            PhotonNetwork.JoinRandomRoom();
        }
        

    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        progress.NetworkState = 0.75f;
        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom(PhotonNetwork.playerName, new RoomOptions() { MaxPlayers = MaxPlayersPerRoom }, null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        progress.NetworkState = 1;

        progress.LoadALevel(LevelName);
    }

    public override void OnDisconnectedFromPhoton()
    {
        progress.Set(false);

        Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");
    }

    #endregion

    #region Offline
    public void Offline()
    {
        if (LevelName == "")
        {
            return;
        }
        levelWindow.SetActive(false);
        progress.Set(true);
        progress.NetworkState = 0.5f;
        PhotonNetwork.offlineMode = true;
        PhotonNetwork.CreateRoom("Offline");
    }

    public void LocalMulti()
    {
        if (PlayerPrefs.GetInt("mod") == 0)
        {
            PlayerPrefs.SetInt("mod", 1);
        }
        else
        {
            PlayerPrefs.SetInt("mod", 0);
        }
        Debug.Log("Set to "+ PlayerPrefs.GetInt("mod"));  
    }
    #endregion

    //}
}