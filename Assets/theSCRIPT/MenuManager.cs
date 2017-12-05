﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	
	//private PatrolMultipleLerp[] pml;

	//private GameObject canvasPauseMenu;
	//private GameObject canvasSceneMenu;
	Animator animor1;
	Animator animor2;
	Animator animor3;
	public GameObject theStar1;
	public GameObject theStar2;
	public GameObject theStar3;

	//GeneralManager gm;
	SoundManager soma;

	public GameObject canvasPauseMenu;
	public GameObject canvasSceneMenu;
	public GameObject canvasResultMenu;
	public GameObject canvasDialogMenu;

	public GameObject thePlayer;

	public Text praiseText;
	public Text scoreText;

	//duplicate manaBar for canvasResultMenu
	public Slider manaBar;

	private Transform panelOfSceneMenu;
	private Image img;

	public float skillDuration;
	float snaegelSpeed;
	float chronicaSpeed;
	public static int lastScene;
	public static string lastSceneString;
	//public static Vector3 lastPosition;
	public static float lastPositionX;
	public static float lastPositionY;
	public static float lastPositionZ;
	bool scanModPause = false;
	string praise;

	// Use this for initialization
	void Start () {
		//gm = FindObjectOfType<GeneralManager> ();
		soma = FindObjectOfType<SoundManager>();
		animor1 = theStar1.GetComponent<Animator> ();
		animor2 = theStar2.GetComponent<Animator> ();
		animor3 = theStar3.GetComponent<Animator> ();

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
		/*
		//img.CrossFadeAlpha (190f, 0.5f, true);

		//canvasPauseMenu.SetActive (true);

		//canvasPauseMenu.transform.GetChild(0).gameObject.SetActive (true);
		//Time.timeScale = 0;
		*/
		soma.buttonSound ();
		StartCoroutine(pausse(0.5f));
	}

	public void resumeTheGame () {
		//Time.timeScale = 1;
		soma.buttonSound ();
		StartCoroutine(unpausse(0.5f));
		/*
		//img.CrossFadeAlpha (0.0f, 0.5f, true);
		//canvasPauseMenu.SetActive (false);
		//canvasPauseMenu.transform.GetChild(0).gameObject.SetActive (false);
		*/
	}

	public void exitTheGame () {
		soma.buttonSound ();

		lastPositionX = thePlayer.transform.localPosition.x;
		lastPositionY = thePlayer.transform.localPosition.y;
		lastPositionZ = thePlayer.transform.localPosition.z;
		//lastPosition = thePlayer.transform.position;
		lastScene = SceneManager.GetActiveScene().buildIndex;
		lastSceneString = SceneManager.GetActiveScene ().name;
		//string lastScene = SceneManager.GetActiveScene().name;

		//menmaLastData.lastScene = lastScene;
		//menmaLastData.lastPosition = lastPosition;

		SaveLoadManager.saloma.Save (lastScene, lastSceneString,
			lastPositionX, lastPositionY, lastPositionZ);
		//GameControl.control.Save(menmaLastData.lastScene, 
			//menmaLastData.lastPosition);
		Debug.Log ("Saved Last Scene: " + lastScene);
		Debug.Log ("Saved Last Position: " + 
			lastPositionX + " " + lastPositionY + " " +lastPositionZ);
		
		SceneManager.LoadScene("M0-Home");
		//SceneManager.LoadScene (0);
		//SceneManager.LoadScene ("Main Menu", LoadSceneMode.Single);
	}

	public void helpTheGame () {
		soma.buttonSound ();
	}

	public void scanningModule () {
		soma.buttonSound ();
		GlobalVariables.originScene = SceneManager.GetActiveScene ().name;
		StartCoroutine(scanMod(0.5f));
	}
	//-----------------------------------------------------	
	public void snaegel () {
		soma.buttonSound ();
		StartCoroutine (snaegelCR ());
		Mana.slashMana (35);
		//gm.skillScoring (50);
	}

	public void chronica () {
		soma.buttonSound ();
		StartCoroutine (chronicaCR ());
		Mana.slashMana (75);
		//gm.skillScoring (100);
	}

	public void opthalos () {
		soma.buttonSound ();
		StartCoroutine (opthalosCR ());
		Mana.slashMana (95);
		//gm.skillScoring (200);
	}
	//-----------------------------------------------------	
	IEnumerator snaegelCR () {
		/*
		for (float i = 1; i <= 2; i += 0.05f) {
			snaegelSpeed = PatrolMultipleLerp.sSpeed;
			snaegelSpeed /= i;
			PatrolMultipleLerp.vSpeed = snaegelSpeed;
			//yield return null;
			yield return new WaitForSeconds(0.2f);
		}
		//PatrolMultipleLerp.speed /= 2;
		yield return new WaitForSeconds (skillDuration);
		for (float i = 2; i >= 1; i -= 0.05f) {
			snaegelSpeed = PatrolMultipleLerp.sSpeed;
			snaegelSpeed /= i;
			PatrolMultipleLerp.vSpeed = snaegelSpeed;
			//yield return null;
			yield return new WaitForSeconds(0.2f);
		}
		//PatrolMultipleLerp.speed *= 2;

		//foreach (PatrolMultipleLerp speed in pml) {
		//pml.speed += 11;
		//}
		*/
		for (float i = 1f; i >= 0.5f; i -= 0.025f) {
			snaegelSpeed = PatrolMultipleLerp.sSpeed;
			snaegelSpeed *= i;
			PatrolMultipleLerp.vSpeed = snaegelSpeed;
			yield return new WaitForSeconds (0.2f);
		}
		yield return new WaitForSeconds (skillDuration);
		for (float i = 0.5f; i <= 1f; i += 0.025f) {
			snaegelSpeed = PatrolMultipleLerp.sSpeed;
			snaegelSpeed *= i;
			PatrolMultipleLerp.vSpeed = snaegelSpeed;
			yield return new WaitForSeconds(0.2f);
		}
	}

	IEnumerator chronicaCR () {
		/*
		for (float i = 1f; i >= 0.0f; i -= 0.025f) {
			chronicaSpeed = PatrolMultipleLerp.sSpeed;
			chronicaSpeed *= i;
			chronicaSpeed = (Mathf.Round(chronicaSpeed * 100))/100;
			PatrolMultipleLerp.vSpeed = chronicaSpeed;
			print (chronicaSpeed);
			//yield return null;
			yield return new WaitForSeconds(0.05f);
		}
		yield return new WaitForSeconds (skillDuration);
		for (float i = 0.0f; i <= 1f; i += 0.025f) {
			chronicaSpeed = PatrolMultipleLerp.sSpeed;
			chronicaSpeed *= i;
			PatrolMultipleLerp.vSpeed = chronicaSpeed;
			print (chronicaSpeed);
			yield return new WaitForSeconds(0.2f);
		}
		*/
		PatrolMultipleLerp.chronicaFlag = true;
		yield return new WaitForSeconds (skillDuration);
		PatrolMultipleLerp.chronicaFlag = false;
	}

	IEnumerator opthalosCR () {
		/*
		GeneralManager.toggleWallMesh (true);
		yield return new WaitForSeconds (skillDuration);
		GeneralManager.toggleWallMesh (false);
		*/
		GeneralManager.wallCollisionDisable = true;
		yield return new WaitForSeconds (skillDuration);
		GeneralManager.wallCollisionDisable = false;
	}
	//-----------------------------------------------------
	IEnumerator pausse (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		canvasPauseMenu.SetActive (true);
		Time.timeScale = 0f;
	}

	IEnumerator unpausse (float waitTime) {
		Time.timeScale = 0.1f;
		yield return new WaitForSecondsRealtime (waitTime);
		canvasPauseMenu.SetActive (false);
		Time.timeScale = 1f;
	}

	IEnumerator scanMod (float waitTime) {
		yield return new WaitForSecondsRealtime (waitTime);
		if (!scanModPause) {
			scanModPause = true;
			Time.timeScale = 0;
		} else if (scanModPause) {
			scanModPause = false;
			Time.timeScale = 1;
		}
		//SceneManager.LoadScene ("ScanningModule");
	}

	IEnumerator waitOneSecond () {
		yield return new WaitForSecondsRealtime (1);
	}

	public void gameFinished (int fScore) {
		canvasResultMenu.SetActive (true);
		/*
		while (Mana.mana > 0) {
			Mana.mana -= 1.0f;
			fScore += 1.0f;
			scoreText.text = fScore.ToString ();
			yield return null;
		}
		*/
		if (fScore >= 800) {
			star3 ();
		} else if (fScore >= 600) {
			star2 ();
		} else if (fScore >= 400) {
			star1 ();
		}

		if (fScore >= 800) {
			if (fScore >= 900) {
				praise = "Magnifico!";
			} else {
				praise = "Excellent!";
			}
		} else if (fScore <= 800) {
			if (fScore >= 700) {
				praise = "Great!";
			} else if (fScore >= 600) {
				praise = "Nice!";
			} else if (fScore < 200) {
				praise = "My Grandma can do better than this";
			} else {
				praise = "Good";
			}
		}
		praiseText.text = praise;
		scoreText.text = fScore.ToString ();
	}

	public IEnumerator gameFinisedIE (int fScore, int fMana) {
		canvasResultMenu.SetActive (true);
		manaBar.value = fMana;
		while (fMana > 0) {
			fMana -= 1;
			manaBar.value = fMana;
			fScore += 1;
			scoreText.text = fScore.ToString ();
			yield return new WaitForSecondsRealtime(0.025f);
		}
		gameFinished (fScore);
	}

	public void star1 () {
		animor1.SetInteger("AnimState", 1);
		animor2.SetInteger("AnimState", 2);
		animor3.SetInteger("AnimState", 2);
	}
	public void star2 () {
		animor1.SetInteger("AnimState", 1);
		animor2.SetInteger("AnimState", 1);
		animor3.SetInteger("AnimState", 2);
	}
	public void star3 () {
		animor1.SetInteger("AnimState", 1);
		animor2.SetInteger("AnimState", 1);
		animor3.SetInteger("AnimState", 1);
	}

	public void closeResult() {
		canvasResultMenu.SetActive (false);
		canvasDialogMenu.SetActive (true);
	}

}
[System.Serializable]
class menmaLastData {
	//public int lastScene;
	//public Vector3 lastPosition;
}
