using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerBall : MonoBehaviour {

	public GameObject windCorr;
	bool inWindCorridor = false;
	Rigidbody rb;

	//public Text insufficientMana;
	public GameObject insufficientMana;
	public static bool manaDepleted = false;

	public Material[] mats;
	Material newMat;
	//int i = 1;

	string currentMat;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		if (manaDepleted) {
			changeMatToDefault ();
			manaDepleted = false;
		}
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
		Mana.canRegen = false;
		if (Mana.mana > 10 || (Mana.mana < 10 && go.name == currentMat)) {
			if (go.name == "Button_Wood") {
				if (currentMat == "Button_Wood") {
					changeMatToDefault ();
				} else {
					Mana.slashMana (10);
					Mana.manaRegenPerSec = -.5f;
					rb.mass = 1;
					currentMat = "Button_Wood";
					gameObject.GetComponent<Renderer> ().material = mats [1];
					Debug.Log ("Wooded");
				}
			} else if (go.name == "Button_Stone") {
				if (currentMat == "Button_Stone") {
					changeMatToDefault ();
				} else {
					Mana.slashMana (10);
					Mana.manaRegenPerSec = -.5f;
					rb.mass = 5;
					currentMat = "Button_Stone";
					gameObject.GetComponent<Renderer> ().material = mats [2];
					Debug.Log ("Stoned");
				}
			} else if (go.name == "Button_Metal") {
				if (currentMat == "Button_Metal") {
					changeMatToDefault ();
				} else {
					Mana.slashMana (10);
					Mana.manaRegenPerSec = -.5f;
					rb.mass = 10;
					currentMat = "Button_Metal";
					gameObject.GetComponent<Renderer> ().material = mats [3];
					Debug.Log ("Metaled");
				}
			}
		} else {
			StartCoroutine (glowInsufficientMana());
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
		Mana.manaRegenPerSec = 1.0f;
		//Mana.canRegen = true;
	}


	IEnumerator glowInsufficientMana () {
		if (Mana.mana < 10) {
			insufficientMana.SetActive (true);
			//insufficientMana.CrossFadeAlpha (0.5f, 1.0f, false);
			//yield return new WaitForSeconds (0.5f);
			//insufficientMana.CrossFadeAlpha (1.0f, 1.0f, false);
		} else {
			insufficientMana.SetActive (false);
			//insufficientMana.CrossFadeAlpha (1.0f, 1.0f, false);
		}
		yield return null;
	}
}

