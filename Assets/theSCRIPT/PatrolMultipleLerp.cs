﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMultipleLerp : MonoBehaviour {
	public float speed = 1.0f;
	public Transform startpos, endpos;
	public Transform[] waypoints;
	int currentStartPoint = 0;
	private float startTime, journeyLength;
	bool goBack = false;

	void Start () {
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

	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;

		if (goBack) {
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
}