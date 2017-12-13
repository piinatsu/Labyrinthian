using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneControl : MonoBehaviour {

	public GameObject loadingSceneCanvas;
	//public Animator rotatingCube;
	//public Animation rotatingCube2;
	//public GameObject currentSceneCanvas;
	public Slider slider;

	AsyncOperation assync;

	public void LoadSceneExample(int i) {
		//currentSceneCanvas.SetActive (false);
		//rotatingCube.Play();
		//rotatingCube2.Play ();
		loadingSceneCanvas.SetActive (true);
		loadingSceneCanvas.SetActive (true);
		loadingSceneCanvas.SetActive (true);
		loadingSceneCanvas.SetActive (true);
		loadingSceneCanvas.SetActive (true);
		loadingSceneCanvas.SetActive (true);
		StartCoroutine (LoadingScreen(i));
	}

	public void LoadSceneAuto () {
		int i = SceneManager.GetActiveScene ().buildIndex;
		string s = SceneManager.GetActiveScene ().name;
		if (s == "Prefinal") {
			loadingSceneCanvas.SetActive (true);
			StartCoroutine (LoadingScreen (12));
		} else {
			loadingSceneCanvas.SetActive (true);
			StartCoroutine (LoadingScreen (i + 1));
		}
	}

	public void startFromScratch () {
		loadingSceneCanvas.SetActive (true);
		StartCoroutine (LoadingScreen (3));
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
