using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

	public GameObject canvasDialogMenu;
	public GeneralManager gm;
	public MenuManager mm;
	int finishScore;

	// Use this for initialization
	void Start () {
		//GameObject obj = GameObject.Find ("CanvasDialogMenu");
		//DialogManager dmInstance = obj.GetComponent<DialogManager> ();
		gm = FindObjectOfType<GeneralManager>();
		mm = FindObjectOfType<MenuManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider target) {
		if (target.tag == "Player") {
			finishScore = gm.theScore;
			mm.gameFinished (finishScore);
			//canvasDialogMenu.SetActive (true);
			//DialogManager.canvasActivation(true);
			Time.timeScale = 0;
		}
		//SceneManager.LoadScene (1 + SceneManager.GetSceneByBuildIndex);
	}
}
