using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource source;
	public AudioClip[] clip;
	// Use this for initialization
	void Awake () {
		//source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void buttonSound() {
		int i = Random.Range (0, clip.Length);
		float volume = Random.Range (.5f, 1.0f);
		source.PlayOneShot (clip [i], volume);
		//btnSnd();
	}

	/*
	void btnSnd () {
		int i = Random.Range (0, clip.Length);
		float volume = Random.Range (.5f, 1.0f);
		source.PlayOneShot (clip [i], volume);
	}
	*/
}
