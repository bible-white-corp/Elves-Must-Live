using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Chat;
using UnityEngine;

public class Chat : MonoBehaviour, IChatClientListener {

    ChatClient chatClient;
    public UITextList chatArea;
    public UIInput input;


    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log(message);
    }

    public void OnChatStateChange(ChatState state)
    {
        
    }

    public void OnConnected()
    {
        
    }

    public void OnDisconnected()
    {
        
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        string msgs = "";
        for (int i = 0; i < senders.Length; i++)
        {
            msgs = string.Format("{0} : {1}", senders[i], messages[i]);
            Debug.Log(msgs);
            chatArea.Add(msgs);
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        if (status == 1)
        {
            chatArea.Add(user + " join");
        }
        else
        {
            chatArea.Add(user + " left");
        }
        
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        
    }

    public void OnUnsubscribed(string[] channels)
    {
        
    }

    public void Send(string str)
    {
        chatClient.Subscribe(new string[] { "MainChat" });
        chatClient.PublishMessage("MainChat", str);
        input.value = "";
    }

    // Use this for initialization
    void Start () {
        string UserName = PlayerPrefs.GetString("PlayerName");
        chatClient = new ChatClient(this);
        // Set your favourite region. "EU", "US", and "ASIA" are currently supported.
        chatClient.ChatRegion = "EU";
        chatClient.Connect("e7c6e9a0-8a91-4063-a912-8a9915e84aad", "1.0", new ExitGames.Client.Photon.Chat.AuthenticationValues(UserName));
        chatClient.Subscribe(new string[] { "MainChat", "SecondChat" });
        chatClient.SetOnlineStatus(1, "");
        chatArea.Clear();
    }
	
	// Update is called once per frame
	void Update () {
        chatClient.Service();
        if (Input.GetKeyDown("t"))
        {
            chatArea.Clear();
        }
    }
}
