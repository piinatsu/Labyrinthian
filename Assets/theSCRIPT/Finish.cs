using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

	public GameObject canvasDialogMenu;

	// Use this for initialization
	void Start () {
		//GameObject obj = GameObject.Find ("CanvasDialogMenu");
		//DialogManager dmInstance = obj.GetComponent<DialogManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider target) {
		if (target.tag == "Player") {
			canvasDialogMenu.SetActive (true);
			//DialogManager.canvasActivation(true);
			Time.timeScale = 0;
		}
	}
}
