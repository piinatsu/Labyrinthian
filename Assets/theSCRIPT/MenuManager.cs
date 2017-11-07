using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	
	//private PatrolMultipleLerp[] pml;

	//private GameObject canvasPauseMenu;
	//private GameObject canvasSceneMenu;

	public GameObject canvasPauseMenu;
	public GameObject canvasSceneMenu;

	private Transform panelOfSceneMenu;
	private Image img;

	int lastScene;
	float snaegelSpeed;
	float chronicaSpeed;

	// Use this for initialization
	void Start () {

		// only get one object
		// pml = (PatrolMultipleLerp) FindObjectsOfType (typeof(PatrolMultipleLerp));
		//PatrolMultipleLerp[] pml = FindObjectsOfType 
			//(typeof(PatrolMultipleLerp)) as PatrolMultipleLerp[];

		//canvasPauseMenu = GameObject.Find ("GOCanvasPauseMenu");
		//canvasSceneMenu = GameObject.Find ("CanvasSceneMenu");

		//panelOfSceneMenu = canvasSceneMenu.transform.GetChild (0);

		canvasPauseMenu.SetActive (false);
		//canvasPauseMenu.transform.GetChild(0).gameObject.SetActive (false);

		//img = panelOfSceneMenu.gameObject.GetComponent<Image> ();
		//img.CrossFadeAlpha (0.0f, 1f, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//-----------------------------------------------------
	public void pauseTheGame () {
		//img.CrossFadeAlpha (190f, 0.5f, true);

		//canvasPauseMenu.SetActive (true);

		//canvasPauseMenu.transform.GetChild(0).gameObject.SetActive (true);
		//Time.timeScale = 0;
		StartCoroutine(pausse(0.5f));
	}

	public void resumeTheGame () {
		//Time.timeScale = 1;
		StartCoroutine(unpausse(0.5f));
		//StartCoroutine(waitOneSecond());

		//img.CrossFadeAlpha (0.0f, 0.5f, true);

		//canvasPauseMenu.SetActive (false);

		//canvasPauseMenu.transform.GetChild(0).gameObject.SetActive (false);
	}
	//-----------------------------------------------------
	public void newGame () {
		//play intro
		//ask for tutorial
		//SceneManager.LoadScene("Neophyte");
		SceneManager.LoadScene (1);
	}

	public void continueLastPlayed () {
		SceneManager.LoadScene (lastScene);
	}

	public void selectLevel () {
		//move to scene of level selection
	}

	public void viewAbout () {
		//move to scene about/help
	}

	public void exitGame () {
		//exit to main menu
		lastScene = SceneManager.GetActiveScene().buildIndex;
		//string lastScene = SceneManager.GetActiveScene().name;

		SceneManager.LoadScene(0);
		//SceneManager.LoadScene ("Main Menu", LoadSceneMode.Single);
	}

	public void quitGame () {
		//exit the application
	}
	//-----------------------------------------------------	
	public void snaegel () {
		StartCoroutine (snaegelCR ());
	}

	public void chronica () {
		StartCoroutine (chronicaCR ());
	}

	public void opthalos () {
		StartCoroutine (opthalosCR ());
	}
	//-----------------------------------------------------	
	IEnumerator snaegelCR () {
		for (float i = 1; i <= 2; i += 0.05f) {
			snaegelSpeed = PatrolMultipleLerp.vSpeed;
			snaegelSpeed /= i;
			PatrolMultipleLerp.vSpeed = snaegelSpeed;
			//yield return null;
			yield return new WaitForSeconds(0.1f);
		}
		//PatrolMultipleLerp.speed /= 2;
		yield return new WaitForSeconds (5f);
		for (float i = 2; i >= 1; i -= 0.05f) {
			snaegelSpeed = PatrolMultipleLerp.vSpeed;
			snaegelSpeed /= i;
			PatrolMultipleLerp.vSpeed = snaegelSpeed;
			//yield return null;
			yield return new WaitForSeconds(0.1f);
		}
		//PatrolMultipleLerp.speed *= 2;

		//foreach (PatrolMultipleLerp speed in pml) {
		//pml.speed += 11;
		//}
	}

	IEnumerator chronicaCR () {
		yield return null;
	}

	IEnumerator opthalosCR () {
		yield return null;
	}
	//-----------------------------------------------------
	IEnumerator pausse (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		canvasPauseMenu.SetActive (true);
		Time.timeScale = 0;

	}

	IEnumerator unpausse (float waitTime) {
		Time.timeScale = 0.1f;
		yield return new WaitForSecondsRealtime (waitTime);
		canvasPauseMenu.SetActive (false);
		Time.timeScale = 1f;
	}

	IEnumerator waitOneSecond () {
		yield return new WaitForSecondsRealtime (1);
	}

}
