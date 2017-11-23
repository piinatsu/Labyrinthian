using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavRef : MonoBehaviour {

	public MenuNavigator meNav;
	public MenuManager meMan;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void meNav_gotoAboutHelp () {
		meNav.gotoAboutHelp ();
	}

	public void meNav_gotoSelectRealm () {
		meNav.gotoSelectRealm ();
	}

	public void meNav_gotoNewGame () {
		meNav.gotoNewGame ();
	}

	public void meNav_gotoQuitGame () {
		//exit the application
	}

	public void meNav_gotoLastPlayed () {
		//SceneManager.LoadScene (lastScene);
	}
}
