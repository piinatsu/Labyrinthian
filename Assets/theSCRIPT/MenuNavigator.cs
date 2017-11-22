using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigator: MonoBehaviour {

	public GameObject help;
	public GameObject about;
	public GameObject left;
	public GameObject right;
	private int index=1;
	private int maxIndex=2;
	private int minIndex=0;

	// Use this for initialization
	void Start () {
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

	public void gotoHome() {
		SceneManager.LoadScene ("M0-Home");
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
	}

	public void gotoLstPlayed () {
		//refer to lastScene on MenuManager
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
