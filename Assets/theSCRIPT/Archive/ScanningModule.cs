using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScanningModule : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void goBackToPrevScene () {
		string orgScn = GlobalVariables.originScene;
		SceneManager.LoadScene (orgScn);
	}
}
