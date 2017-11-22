using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour {

	public Transform slidingDoorClosedPos;
	public Transform slidingDoorOpenedPos;
	public GameObject theSlidingDoor;
	float startTime, journeyLength;
	bool openTheDoor = false;
	//bool doorOpened = false;
	bool doorInit = true;
	public bool oneTimeOnly = false;

	void Start () {
		
	}

	void Update () {
		float distCovered = (Time.time - startTime);
		float fracJourney = distCovered / journeyLength * 0.2f;

		if (openTheDoor) {
			/*theSlidingDoor.transform.position = Vector3.Lerp 
				(slidingDoorClosedPos.position, slidingDoorOpenedPos.position, 
				fracJourney);*/
			theSlidingDoor.transform.position = Vector3.Lerp 
				(theSlidingDoor.transform.position, slidingDoorOpenedPos.position, 
					fracJourney);
			//if (fracJourney >= 1f)
				//doorOpened = true;
		} else if (!openTheDoor && !doorInit) {
			//Debug.Log ("aaa");
			/*theSlidingDoor.transform.position = Vector3.Lerp 
				(slidingDoorOpenedPos.position, slidingDoorClosedPos.position, 
					fracJourney);*/
			theSlidingDoor.transform.position = Vector3.Lerp 
				(theSlidingDoor.transform.position, slidingDoorClosedPos.position, 
					fracJourney);
			//if (fracJourney >= 1f)
				//doorOpened = false;
		}
	}

	/*
	public void closeSesame () {
		startTime = Time.time;
		//journeyLength = Vector3.Distance
			//(slidingDoorOpenedPos.position, slidingDoorClosedPos.position);
		journeyLength = Vector3.Distance
			(theSlidingDoor.transform.position, slidingDoorClosedPos.position);
		openTheDoor = false;
		//StartCoroutine(sesame(slidingDoorOpenedPos, slidingDoorClosedPos,
			//startTime, journeyLength));
	}*/
	/*
	public void openSesame () {
		startTime = Time.time;
		//journeyLength = Vector3.Distance
			//(slidingDoorClosedPos.position, slidingDoorOpenedPos.position);
		journeyLength = Vector3.Distance
			(theSlidingDoor.transform.position, slidingDoorOpenedPos.position);
		openTheDoor = true;
		//StartCoroutine(sesame(slidingDoorClosedPos, slidingDoorOpenedPos,
			//startTime, journeyLength));
	}*/

	public void OnTriggerEnter (Collider coll) {
		//openSesame ();
		startTime = Time.time;
		journeyLength = Vector3.Distance
			(theSlidingDoor.transform.position, slidingDoorOpenedPos.position);
		openTheDoor = true;
		doorInit = false;
	}

	public void OnTriggerExit (Collider coll) {
		//closeSesame ();
		startTime = Time.time;
		if (!oneTimeOnly) {
		journeyLength = Vector3.Distance
			(theSlidingDoor.transform.position, slidingDoorClosedPos.position);
		openTheDoor = false;
		}
	}

	/*
	IEnumerator sesame (Transform pos1, Transform pos2, float st, float jl) {
		yield return null;
		float distCovered = (Time.time - st);
		float fracJourney = distCovered / jl * 0.1f;
		transform.position = Vector3.Lerp 
			(pos1.position, pos2.position, 
				fracJourney);
		Debug.Log ("slide");
		//yield return null;
	}*/
}
