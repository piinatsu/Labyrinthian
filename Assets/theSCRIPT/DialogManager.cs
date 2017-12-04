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
	bool isAncientText = false;

	// Use this for initialization
	void Start () {
		//canvasDialogMenu = GetComponent<Canvas> ();
		//GameObject obj = GameObject.Find ("CanvasDialogMenu");
		//DialogManager dmInstance = obj.GetComponent<DialogManager> ();
		canvasDialogMenu.SetActive (false);
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
		if (isAncientText) {
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

	public void nextDialog () {
		if (isAncientText) {
			currentLineAncient++;
		} else {
			currentLine++;
		}
	}

	public void previousDialog () {
		if (isAncientText) {
			currentLineAncient--;
		} else {
			currentLine--;
		}
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
