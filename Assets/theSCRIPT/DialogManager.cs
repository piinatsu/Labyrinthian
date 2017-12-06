using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public GameObject canvasDialogMenu;

	public Text textContainer;

	public TextAsset textFile;
	public TextAsset textFileAncient;
	string[] textLines;
	string[] textLinesAncient;

	//public int currentLine;
	//public int endAtLine;

	public int startLine;
	public int endLine;
	public int startLineAncient;
	public int endLineAncient;
	int currentLine;
	int currentLineAncient;
	public static bool isAncientText = false;

	// Use this for initialization
	void Start () {
		//canvasDialogMenu = GetComponent<Canvas> ();
		//GameObject obj = GameObject.Find ("CanvasDialogMenu");
		//DialogManager dmInstance = obj.GetComponent<DialogManager> ();

		//canvasDialogMenu.SetActive (false);

		//textContainer = gameObject.GetComponent<Text> ();

		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}
		if (textFileAncient != null) {
			textLinesAncient = (textFileAncient.text.Split ('\n'));
		}

		if (endLine == 0) {
			endLine = textLines.Length - 1;
		}

		currentLine = startLine;
		currentLineAncient = startLineAncient;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (canvasDialogMenu.activeSelf) {
			if (isAncientText) {
				Debug.Log (textLinesAncient [currentLineAncient]);
				textContainer.text = textLinesAncient [currentLineAncient];
				if (currentLineAncient > endLineAncient) {
					Time.timeScale = 1;
					canvasDialogMenu.SetActive (false);
				} else {
					textContainer.text = textLines [currentLine];
					if (currentLine > endLine) {
						Time.timeScale = 1;
						canvasDialogMenu.SetActive (false);
					}
				}
			}
		}
		*/
	}

	void proceedDialog () {
		if (isAncientText) {
			if (currentLineAncient <= endLineAncient) {
				textContainer.text = textLinesAncient [currentLineAncient];
			} else if (currentLineAncient > endLineAncient) {
				Time.timeScale = 1;
				canvasDialogMenu.SetActive (false);
			}

		} else {
			if (currentLine <= endLine) {
				textContainer.text = textLines [currentLine];
			} else if (currentLine > endLine) {
				Time.timeScale = 1;
				canvasDialogMenu.SetActive (false);
			}
		}
	}

	public void nextDialog () {
		Debug.Log ("Next Dialog");
		if (isAncientText)
			currentLineAncient++;
		else
			currentLine++;
		proceedDialog ();
	}

	public void previousDialog () {
		Debug.Log ("Previous Dialog");
		if (isAncientText) {
			currentLineAncient--;
		} else {
			currentLine--;
		}
		proceedDialog ();
	}

	public static void canvasActivation (bool tof) {
		/*
		//GameObject obj = GameObject.Find ("CanvasDialogMenu");
		//DialogManager dm = GetComponent<DialogManager> ();

		//canvasDialogMenu.SetActive (tof);
		//dm.canvasDialogMenu.SetActive (tof);
		//obj.SetActive (tof);
		*/
	}
}
