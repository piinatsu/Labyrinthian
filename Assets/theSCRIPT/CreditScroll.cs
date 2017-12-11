using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditScroll : MonoBehaviour {

	public RectTransform rectTransform;
	public RectTransform creditsText;
	public RectTransform accelerateButton;
	public GameObject goBackButton;
	int topp = 0;
	int botom = 900;
	int creditsTextY = -1080;
	bool accelerate = false;
	int pullStep;
	public int pullStepMin = 2;
	public int pullStepMax = 8;

	IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		//InvokeRepeating("scrollDown", 1.0f, 0.1f);
		//InvokeRepeating("pullCreditsUp", 1.0f, 0.1f);
		//StartCoroutine(pullCreditsUp(pullSpeed));
		coroutine = pullCreditsUp(pullStepMin);
		StartCoroutine(coroutine);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		/*
		while (creditsTextY < 1080) {
			creditsTextY += 1;
			creditsText.transform.localPosition = new Vector3 (0, creditsTextY, 0);
			accelerateButton.transform.localPosition = new Vector3 (0, creditsTextY, 0);
			Debug.Log (accelerate);
		}
		*/
	}

	void scrollDown () {
		botom -= 1;
		topp -= 1;
		rectTransform.offsetMin = new Vector2 (rectTransform.offsetMin.x, botom);
		rectTransform.offsetMax = new Vector2 (rectTransform.offsetMin.x, topp);
	}

	IEnumerator pullCreditsUp (int step) {
		while (creditsTextY <= 1080) {
			Debug.Log (step);
			creditsTextY += step;
			creditsText.transform.localPosition = new Vector3 (0, creditsTextY, 0);
			//accelerateButton.transform.localPosition = new Vector3 (0, creditsTextY, 0);
			yield return new WaitForSeconds (0.04f);
		}
		goBackButton.SetActive (true);
	} 

	public void accelerateCredits () {
		Debug.Log ("ACCELERATE");
		if (!accelerate) {
			pullStep = pullStepMax;
			accelerate = true;
			//StopCoroutine (pullCreditsUp(pullSpeed));
			StopCoroutine(coroutine);
		} else if (accelerate) {
			pullStep = pullStepMin;
			accelerate = false;
			//StopCoroutine (pullCreditsUp(pullSpeed));
			StopCoroutine(coroutine);
		}
		//StartCoroutine(pullCreditsUp(pullSpeed));
		coroutine = pullCreditsUp(pullStep);
		StartCoroutine(coroutine);
	}

	public void creditsEndsNowGoBack () {
		SceneManager.LoadScene ("M0-Home");
	}
}
