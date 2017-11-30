using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBall : MonoBehaviour {

	public GameObject windCorr;
	bool inWindCorridor = false;
	Rigidbody rb;

	public Material[] mats;
	Material newMat;
	int i = 1;

	string currentMat;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {

	}

	void FixedUpdate () {
		if (inWindCorridor) {
			rb.AddForce (windCorr.GetComponent<WindCorridor>().windDirection *
				windCorr.GetComponent<WindCorridor>().windStrength);
		}
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.gameObject.tag == "WindCorridor") {
			windCorr = coll.gameObject;
			inWindCorridor = true;
			Debug.Log ("inWindCorridor = true");
		}
	}

	void OnTriggerExit (Collider coll) {
		if (coll.gameObject.tag == "WindCorridor") {
			inWindCorridor = false;
			Debug.Log ("inWindCorridor = false");
		}
	}

	public void changeMaterial () {
		GameObject go = EventSystem.current.currentSelectedGameObject;
		if (go.name == "Button_Wood") {
			if(currentMat == "Wood")
				changeMatToDefault ();
			rb.mass = 1;
			currentMat = "Wooded";
			gameObject.GetComponent<Renderer>().material = mats[1];
			Debug.Log ("Clicked on wood");
		} else if (go.name == "Button_Stone") {
			if(currentMat == "Stone")
				changeMatToDefault ();
			rb.mass = 5;
			currentMat = "Stone";
			gameObject.GetComponent<Renderer>().material = mats[2];
			Debug.Log ("Stoned");
		} else if (go.name == "Button_Metal") {
			if(currentMat == "Metal") 
				changeMatToDefault ();
			rb.mass = 10;
			currentMat = "Metal";
			gameObject.GetComponent<Renderer>().material = mats[3];
			Debug.Log ("Metaled");
		}
		/*
		if (i > mats.Length - 1) i = 0;
		switch (i) {
		case 0:
			rb.mass = 1; break;
		case 1:
			rb.mass = 5; break;
		case 2:
			rb.mass = 10; break;
		case 3:
			rb.mass = 20; break;
		default:
			print ("check yo code, yo!");
			break;
		}
		//GetComponent<Renderer> ().material = mats [i];
		gameObject.GetComponent<Renderer>().material = mats[i];
		i++;
		*/

	}

	void changeMatToDefault () {
		gameObject.GetComponent<Renderer>().material = mats[0];
		currentMat = "Default";
		rb.mass = 1;
	}
}
