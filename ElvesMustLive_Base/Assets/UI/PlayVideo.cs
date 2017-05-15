using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour {


	public MovieTexture movie;
	public AudioSource audio;
	float timer;

	// Use this for initialization
	void Start () 
	{
		GetComponent<RawImage>().texture = movie as MovieTexture;
		timer = 0f;
		movie.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) || timer > 5.7f)
		{
			SceneManager.LoadScene("Lobby");
		}
		timer += Time.deltaTime;
	}
}
