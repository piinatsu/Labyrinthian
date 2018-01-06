using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour {

	public AudioSource asr;
	public AudioClip ac1;
	public AudioClip ac2;

	void Awake () {
		//GameObject BGM_Holder = GetComponent<AudioSource>();
		int sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		if (sceneIndex == 0 || sceneIndex == 1 || sceneIndex == 2) {
			GameObject[] objs = GameObject.FindGameObjectsWithTag ("BGMMain");
			GameObject obj = GameObject.FindGameObjectWithTag ("BGMGame");
			if (obj != null)
				Destroy (obj);
			if (objs.Length > 1)
				Destroy (this.gameObject);
			DontDestroyOnLoad (this.gameObject);
		} else  if (sceneIndex == 7 || sceneIndex == 6 || sceneIndex == 5 || sceneIndex == 4 || sceneIndex == 3 ) {
			GameObject[] objs = GameObject.FindGameObjectsWithTag ("BGMGame");
			GameObject obj = GameObject.FindGameObjectWithTag ("BGMMain");
			if (obj != null)
				Destroy (obj);
			if (objs.Length > 1)
				Destroy (this.gameObject);
			DontDestroyOnLoad (this.gameObject);
			//Destroy (this.gameObject);
		}

		//GameObject[] objs = GameObject.FindGameObjectsWithTag ("BGMMain");
		//if (objs.Length > 1) {
		//	Destroy (this.gameObject);
		//}
		//DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
