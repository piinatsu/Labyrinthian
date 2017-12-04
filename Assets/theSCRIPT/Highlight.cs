using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour {

	bool isHighlighted = false;
	public Material mat1;
	public Material mat2;
	public static Transform triggeredAOSLocation;
	GameObject go;
	bool isActiveObject = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (!isHighlighted) {
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					go = hit.collider.gameObject;
					if (go.tag == "ActiveObject") {
						go.GetComponent<Renderer> ().material = mat2;
						isHighlighted = true;
						isActiveObject = true;
					}
				}
				if(isActiveObject)
					ActiveObjectSpawner.spawnObject (go);
			} else if (isHighlighted) {
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					go = hit.collider.gameObject;
					if (go.tag == "ActiveObject") {
						go.GetComponent<Renderer> ().material = mat1;
						isHighlighted = false;
						isActiveObject = true;
					}
				}
				if(isActiveObject)
					ActiveObjectSpawner.spawnObject (new GameObject());
			}
		}
	}
	/*
	void OnMouseDown () {
		isHighlighted = !isHighlighted;
		if (gameObject.name == "ramp")
			Debug.Log ("Ramp");
		else if (gameObject.name == "bridge_ramp")
			Debug.Log ("Ramp");
		else if (gameObject.name == "coiled_spring")
			Debug.Log ("Ramp");
		// if no one is highlighted turn off all
		if (isHighlighted) 
			gameObject.GetComponent<Renderer> ().material = mat1;
		else if(!isHighlighted) 
			gameObject.GetComponent<Renderer> ().material = mat2;
		//Instantiate (go, triggeredAOSLocation.transform.position,
			//triggeredAOSLocation.transform.rotation);
		
	}
	*/		
}
