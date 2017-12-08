using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMultipleLerp : MonoBehaviour {
	public float speed;
	public static float sSpeed;
	public static float vSpeed;
	public Transform startpos, endpos;
	public Transform[] waypoints;
	int currentStartPoint = 0;
	private float startTime, journeyLength;
	bool goBack = false;
	public static bool chronicaFlag = false;
	public SoundManager soma;
	public AudioSource ausrc;
	public MenuManager menma;

	void Start () {
		sSpeed = speed;
		vSpeed = speed;
		currentStartPoint = 0;
		setPointsPlus();
	}

	void setPointsPlus() {
		startpos = waypoints [currentStartPoint];
		endpos = waypoints [currentStartPoint + 1];
		startTime = Time.time;
		journeyLength = Vector3.Distance
			(startpos.position, endpos.position);
	}

	void setPointsMinus() {
		startpos = waypoints [currentStartPoint];
		endpos = waypoints [currentStartPoint - 1];
		startTime = Time.time;
		journeyLength = Vector3.Distance
			(startpos.position, endpos.position);
	}

	void setPointsChronica () {
		//endpos = startpos = waypoints [currentStartPoint];
		float distCovered = (Time.time - startTime) * vSpeed;
		float fracJourney = distCovered / journeyLength;
		if (fracJourney < 1f) {
			transform.position = Vector3.Lerp 
				(startpos.position, endpos.position, fracJourney);
		}
	}

	void Update () {
		//print (vSpeed);
		float distCovered = (Time.time - startTime) * vSpeed;
		float fracJourney = distCovered / journeyLength;

		if (chronicaFlag == true) {
			setPointsChronica ();
		} else if (goBack) {
			transform.position = Vector3.Lerp 
				(startpos.position, endpos.position, fracJourney);
			if (fracJourney >= 1f && currentStartPoint - 1 > 0) {
				currentStartPoint--;
				setPointsMinus ();
			} else if (fracJourney >= 1f && currentStartPoint - 1 == 0) {
				currentStartPoint -= 1;
				goBack = false;
				setPointsPlus ();
			}

		} else if (!goBack) {
			transform.position = Vector3.Lerp 
				(startpos.position, endpos.position, fracJourney);
			if (fracJourney >= 1f && currentStartPoint + 1 < waypoints.Length) {
				currentStartPoint++;
				if(currentStartPoint + 1 < waypoints.Length)
					setPointsPlus ();
			} else if (fracJourney >= 1f && currentStartPoint + 1 == waypoints.Length) {
				goBack = true;
				setPointsMinus ();
			}
		}
	}

	void OnTriggerEnter(Collider target) {
		if (target.tag == "Player") {
			Debug.Log ("Player Detected");
			string playerMat = target.gameObject.
				GetComponent<Renderer> ().material.name;
			string enemyMat = gameObject.
				GetComponent<Renderer> ().material.name;
			if (playerMat == "White (Instance)") {
				Destroy (target.gameObject);
				menma.deathPause ();
			} else if (enemyMat == "Red (Instance)" && 
				playerMat == "WoodSurface (Instance)") {
				//soma.buttonSound ();
				//soma.deathSound();
				//ausrc.Play ();
				Debug.Log ("Player Hit");
				Destroy (target.gameObject);
				menma.deathPause ();
				//StartCoroutine(hideThenDestroy(target.gameObject));
			} else if (enemyMat == "Yellow (Instance)" && 
				playerMat == "MetalSurface (Instance)") {
				//soma.buttonSound ();
				//soma.deathSound();
				//ausrc.Play ();
				Debug.Log ("Player Hit");
				Destroy (target.gameObject);
				menma.deathPause ();
				//StartCoroutine(hideThenDestroy(target.gameObject));
			} else if (enemyMat == "Light Blue (Instance)" && 
				playerMat == "StoneSurface (Instance)") {
				//soma.buttonSound ();
				//soma.deathSound();
				//ausrc.Play ();
				Debug.Log ("Player Hit");
				Destroy (target.gameObject);
				menma.deathPause ();
				//StartCoroutine(hideThenDestroy(target.gameObject));
			}
		}
	}

	IEnumerator hideThenDestroy (GameObject tgt) {
		tgt.SetActive (false);
		yield return new WaitForSeconds (1.5f);
		Destroy (tgt);
	}
}
