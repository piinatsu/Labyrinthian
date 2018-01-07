using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigator: MonoBehaviour {

	public GameObject help;
	public GameObject about;
	public GameObject left;
	public GameObject right;
	private int index=1;
	private int maxIndex=2;
	private int minIndex=0;
	public Sprite lockIMG;
	public Sprite unlockIMG;
	public Button stageUnlockerBtn;

	public Button[] stageButton;

	// Use this for initialization
	void Start () {
		for (int i = 2; i <= 5; i++) {
			if (PlayerPrefs.GetString ("StageUnlocked"+i) == "true") {
				stageButton [i - 2].interactable = true;
			} else if (PlayerPrefs.GetString ("StageUnlocked"+i) == "false") {
				stageButton [i - 2].interactable = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void gotoTherePlease (int index) {
		if (index == 0) {
			gotoHome ();
		} else if (index == 1) {
			gotoHelp ();
		} else if (index == 2) {
			gotoAbout ();
		}
	}

	public void rightArrow () {
		if (index + 1 <= maxIndex) {
			index += 1;
			right.SetActive (true);
			left.SetActive (true);
		} if (index + 1 > maxIndex) {
			right.SetActive (false);
		}
		print ("right arrow " + index);
		gotoTherePlease (index);
	}

	public void leftArrow () {
		if (index - 1 >= minIndex) {
			index -= 1;
			left.SetActive (true);
			right.SetActive (true);
		} //if (index - 1 < minIndex) {
			//left.SetActive (false);
		//}
		print ("left arrow " + index);
		gotoTherePlease (index);
	}

	void gotoHelp() {
		help.SetActive(true);
		about.SetActive(false);
	}

	void gotoAbout() {
		about.SetActive(true);
		help.SetActive(false);
	}

	void gotoQuit () {
		Application.Quit ();
	}

	public void gotoHome() {
		SceneManager.LoadScene ("M0-Home");
	}

	public void resetScore () {
		for (int i = 3; i <= 7; i++) {
			PlayerPrefs.SetInt ("HighestScore"+i, 1);
		}
		//PlayerPrefs.SetInt ("HighestScore3", 1);
		//PlayerPrefs.SetInt ("HighestScore4", 1);
		//PlayerPrefs.SetInt ("HighestScore5", 1);
		//PlayerPrefs.SetInt ("HighestScore6", 1);
		//PlayerPrefs.SetInt ("HighestScore7", 1);
	}

	public void stageUnlocker () {
		if (PlayerPrefs.GetInt ("StageUnlocked") == 0) {
			for (int i = 2; i <= 5; i++)
				PlayerPrefs.SetString ("StageUnlocked"+i, "true");
			PlayerPrefs.SetInt ("StageUnlocked", 1);
			stageUnlockerBtn.image.sprite = unlockIMG;
		} else if (PlayerPrefs.GetInt ("StageUnlocked") == 1) {
			for (int i = 2; i <= 5; i++)
				PlayerPrefs.SetString ("StageUnlocked"+i, "false");
			PlayerPrefs.SetInt ("StageUnlocked", 0);
			stageUnlockerBtn.image.sprite = lockIMG;
		}

		for (int i = 2; i <= 5; i++) {
			if (PlayerPrefs.GetString ("StageUnlocked"+i) == "true") {
				stageButton [i - 2].interactable = true;
			} else if (PlayerPrefs.GetString ("StageUnlocked"+i) == "false") {
				stageButton [i - 2].interactable = false;
			}
		}
	}

	public void unlockStage() {
		for (int i = 2; i <= 5; i++)
			PlayerPrefs.SetString ("StageUnlocked"+i, "true");
	}

	public void lockStage() {
		for (int i = 2; i <= 5; i++)
			PlayerPrefs.SetString ("StageUnlocked"+i, "false");
	}

	public void gotoAboutHelp () {
		index = 1;
		SceneManager.LoadScene("M1-AboutHelp");
	}

	public void gotoNewGame () {
		//play intro
		//ask for tutorial
		//SceneManager.LoadScene("Neophyte");
		//SceneManager.LoadScene (1);
	}

	public void gotoQuitGame () {
		Application.Quit ();
	}

	public void gotoLastPlayed () {
		//refer to lastScene on MenuManager
		SaveLoadManager.saloma.Load ();
		int lastScene = SaveLoadManager.saloma.lastScene;
		//GeneralManager.genma.is
		GeneralManager.isContinueLast = true;
		SceneManager.LoadScene (lastScene);

		//SceneManager.LoadScene(MenuManager.lastScene);
	}
	//----------------------------------------------

	public void gotoSelectRealm () {
		SceneManager.LoadScene("M2-SelectRealm");
	}
	public void gotoR0 () {
		SceneManager.LoadScene ("R0-Tutorial");
	}
	public void gotoR1 () {
		SceneManager.LoadScene ("R1-Neophyte");
	}
	public void gotoR2 () {
		SceneManager.LoadScene ("R2-Solitore");
	}
	public void gotoR3 () {
		SceneManager.LoadScene ("R3-Helixian");
	}
	public void gotoR4 () {
		SceneManager.LoadScene ("R4-Trearchy");
	}

}
