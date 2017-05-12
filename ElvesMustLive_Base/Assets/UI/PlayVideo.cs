using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour {


	public MovieTexture movie;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		GetComponent<RawImage>().texture = movie as MovieTexture;

		movie.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene("Lobby");
		}
	}
}
