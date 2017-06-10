using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour {


    public MovieTexture movie;
    public AudioClip audioClip;
	float timer;
    float maxTime;
	// Use this for initialization
	void Start () 
	{
        /*
        switch (PlayerPrefs.GetInt("Cin"))
        {
            case 0:
                maxTime = 6.1f;
                break;
            case 1:
                maxTime = 10f;
                break;
            case 2:
                maxTime = 10f;
                break;
            default:
                break;
        }*/
        maxTime = movie.duration;
        if (maxTime < 6)
        {
            maxTime = 6.1f;
        }
        GetComponent<RawImage>().texture = movie as MovieTexture;
        if (audioClip == null)
        {
            GetComponent<AudioSource>().clip = movie.audioClip;
        }
        else
        {
            GetComponent<AudioSource>().clip = audioClip;
        }
		timer = 0f;
		movie.Play();
        GetComponent<AudioSource>().Play();

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) || timer > maxTime)
		{
            Debug.Log("Quit" + timer);
			SceneManager.LoadScene("Lobby");
		}
		timer += Time.deltaTime;
	}
}
