using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	private GameObject canvasPauseMenu;
	private GameObject canvasSceneMenu;

	private Transform panelOfSceneMenu;
	private Image img;

	// Use this for initialization
	void Start () {
		canvasPauseMenu = GameObject.Find ("GOCanvasPauseMenu");
		canvasSceneMenu = GameObject.Find ("CanvasSceneMenu");

		panelOfSceneMenu = canvasSceneMenu.transform.GetChild (0);

		//canvasPauseMenu.SetActive (false);
		canvasPauseMenu.transform.GetChild(0).gameObject.SetActive (false);

		img = panelOfSceneMenu.gameObject.GetComponent<Image> ();
		img.CrossFadeAlpha (0.0f, 1f, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pauseTheGame () {
		img.CrossFadeAlpha (128f, 1f, true);

		//canvasPauseMenu.SetActive (true);
		canvasPauseMenu.transform.GetChild(0).gameObject.SetActive (true);
		Time.timeScale = 0;
	}

	public void resumeTheGame () {
		Time.timeScale = 1;

		img.CrossFadeAlpha (0.0f, 1f, true);
		//canvasPauseMenu.SetActive (false);
		canvasPauseMenu.transform.GetChild(0).gameObject.SetActive (false);
	}
}
