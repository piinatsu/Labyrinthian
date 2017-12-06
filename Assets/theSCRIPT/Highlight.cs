using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour {

	bool isHighlighted = false;
	public Material mat1;
	public Material mat2;
	public static Transform triggeredAOSLocation;
	public static GameObject go;
	GameObject go2;
	//bool isActiveObject = false;
	public GameObject activeObjectHolder;
	string stringGOToBeActivated;

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
					if (go.CompareTag("ActiveObject")) {
						stringGOToBeActivated = go.name;
						go.GetComponent<Renderer> ().material = mat2;
						isHighlighted = true;
						//isActiveObject = true;
						go2 = activeObjectHolder.transform.
							Find (stringGOToBeActivated).gameObject;
						go2.SetActive(true);
					}
				}
				//if(isActiveObject)
					//ActiveObjectSpawner.spawnObject (go);
			} else if (isHighlighted) {
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					go = hit.collider.gameObject;
					if (go.tag == "ActiveObject") {
						stringGOToBeActivated = go.name;
						go.GetComponent<Renderer> ().material = mat1;
						isHighlighted = false;
						//isActiveObject = true;
						go2 = activeObjectHolder.transform.
							Find (stringGOToBeActivated).gameObject;
						go2.SetActive(false);
					}
				}
				//if(isActiveObject)
					//ActiveObjectSpawner.spawnObject (new GameObject());
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
