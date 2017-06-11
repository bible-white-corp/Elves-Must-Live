using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour {

    public VideoPlayer video;

    //public MovieTexture movie;
    //public AudioClip audioClip;
	float timer;
    float maxTime;
	// Use this for initialization
	void Start () 
	{
        video = GetComponent<VideoPlayer>();
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
        /*maxTime = video.
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
        */

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) || video.frame == (long)video.frameCount -1)
		{
            //Debug.Log("Quit" + timer);
			SceneManager.LoadScene("Lobby");
		}
		timer += Time.deltaTime;
	}
}
