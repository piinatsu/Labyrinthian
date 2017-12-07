using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneControl : MonoBehaviour {

	public GameObject loadingSceneCanvas;
	public GameObject currentSceneCanvas;
	public Slider slider;

	AsyncOperation assync;

	public void LoadSceneExample(int i) {
		currentSceneCanvas.SetActive (false);
		loadingSceneCanvas.SetActive (true);
		StartCoroutine (LoadingScreen(i));
	}

	IEnumerator LoadingScreen(int i) {
		
		//SceneManager.LoadScene(10);
		assync = SceneManager.LoadSceneAsync (i);
		assync.allowSceneActivation = false;

		while (assync.isDone == false) {
			slider.value = assync.progress;
			if (assync.progress == 0.9f) {

				slider.value = 1f;
				assync.allowSceneActivation = true;
			}
			yield return null;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
