using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMMain : MonoBehaviour {

	void Awake () {
		int sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		if (sceneIndex == 0 || sceneIndex == 1 || sceneIndex == 2) {
			GameObject[] objs = GameObject.FindGameObjectsWithTag ("BGMMain");
			if (objs.Length > 1) {
				Destroy (this.gameObject);
			}
			DontDestroyOnLoad (this.gameObject);
		} else  if (SceneManager.GetActiveScene ().buildIndex > 2) {
			Destroy (this.gameObject);
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
