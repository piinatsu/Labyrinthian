using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigator: MonoBehaviour {

	public GameObject help;
	public GameObject about;
	public GameObject left;
	public GameObject right;
	private int index;
	private int maxIndex;
	private int minIndex;

	// Use this for initialization
	void Start () {
		int index = 1;
		int maxIndex = 2;
		int minIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (index == 0) {
			gotoHome ();
		} else if (index == 1) {
			gotoHelp ();
		} else if (index == 2) {
			gotoAbout ();
		}
	}

	public void rightArrow () {
		if (index + 1 < maxIndex) {
			index += 1;
			right.SetActive (true);
		} else if (index + 1 >= maxIndex) {
			right.SetActive (false);
		}
	}

	public void leftArrow () {
		if (index - 1 > minIndex) {
			index -= 1;
			left.SetActive (true);
		} else if (index + 1 <= minIndex) {
			left.SetActive (false);
		}
	}

	public void gotoHelp() {
		help.SetActive(true);
		about.SetActive(false);
	}

	public void gotoAbout() {
		about.SetActive(true);
		help.SetActive(false);
	}

	public void gotoHome() {
		SceneManager.LoadScene ("MenuMain");
	}

	public void gotoAboutHelp () {
		SceneManager.LoadScene("MenuAboutHelp");
	}
}
