using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

	//public GameObject canvasDialogMenu;

	public GeneralManager gm;
	public MenuManager mm;

	int finishScore;
	int manaFinish;

	// Use this for initialization
	void Start () {
		//GameObject obj = GameObject.Find ("CanvasDialogMenu");
		//DialogManager dmInstance = obj.GetComponent<DialogManager> ();

		//gm = FindObjectOfType<GeneralManager>();
		//mm = FindObjectOfType<MenuManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider target) {
		if (target.tag == "Player" || target.CompareTag("Invincible")) {
			finishScore = gm.theScore;
			manaFinish = (int) Mana.mana;
			//mm.gameFinished (finishScore); //displays canvasResultMenu at MenuManager
			StartCoroutine(mm.gameFinisedIE(finishScore, manaFinish));
			//canvasDialogMenu.SetActive (true);
			//DialogManager.canvasActivation(true);
			Time.timeScale = 0;
		}
		//SceneManager.LoadScene (1 + SceneManager.GetSceneByBuildIndex);
	}
	/*
	IEnumerator drainManaToScore () {
		while (Mana.mana > 0) {
			Mana.mana -= 1f;
		}
	}
	*/
}
