using UnityEngine;
using UnityEngine.UI;


using System.Collections;


//namespace Com.MyCompany.MyGame
//{
/// <summary>
/// Player name input field. Let the user input his name, will appear above the player in the game.
/// </summary>
public class PlayerNameInputField : MonoBehaviour
{
    #region Private Variables

    #endregion


    #region MonoBehaviour CallBacks


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during initialization phase.
    /// </summary>
    void Start()
    {
        string defaultName = "";
        UIInput _inputField = GetComponentInChildren<UIInput>();
        if (_inputField != null)
        {
            if (PlayerPrefs.HasKey("PlayerName"))
            {
                defaultName = PlayerPrefs.GetString("PlayerName");
                _inputField.value = defaultName;
            }
        }


        PhotonNetwork.playerName = defaultName;
    }


    #endregion


    #region Public Methods


    /// <summary>
    /// Sets the name of the player, and save it in the PlayerPrefs for future sessions.
    /// </summary>
    /// <param name="value">The name of the Player</param>
    public void SetPlayerName(string value)
    {
        // #Important
        PhotonNetwork.playerName = value + " "; // force a trailing space string in case value is an empty string, else playerName would not be updated.


        PlayerPrefs.SetString("PlayerName", value);
        Debug.Log(PhotonNetwork.playerName + " " + PlayerPrefs.GetString("PlayerName"));
    }


    #endregion
}
//}