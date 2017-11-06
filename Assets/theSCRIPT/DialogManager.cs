using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public GameObject canvasDialogMenu;

	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	// Use this for initialization
	void Start () {
		//canvasDialogMenu = GetComponent<Canvas> ();
		//GameObject obj = GameObject.Find ("CanvasDialogMenu");
		//DialogManager dmInstance = obj.GetComponent<DialogManager> ();
		canvasDialogMenu.SetActive (false);
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		theText.text = textLines [currentLine];

		if (currentLine > endAtLine) {
			Time.timeScale = 1;
			canvasDialogMenu.SetActive (false);
		}
	}

	public void nextDialog () {
		currentLine++;
	}

	public static void canvasActivation (bool tof) {
		//GameObject obj = GameObject.Find ("CanvasDialogMenu");
		//DialogManager dm = GetComponent<DialogManager> ();

		//canvasDialogMenu.SetActive (tof);
		//dm.canvasDialogMenu.SetActive (tof);
		//obj.SetActive (tof);
	}
}
