using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefinalSpecialScript : MonoBehaviour {
	public GameObject canvasDialog;
	public LoadingSceneControl loading;
	// Use this for initialization
	void Start () {
		canvasDialog.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void prefinalDone () {
		loading.LoadSceneAuto ();
	}
}
