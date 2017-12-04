using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorClick : MonoBehaviour {
	bool isHighlighted = false;
	GameObject go;
	public Material mat1;
	public Material mat2;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {
			if (!isHighlighted) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					go = hit.collider.gameObject;
					hit.collider.gameObject.GetComponent<Renderer> ().
					material.color = Color.red;
					isHighlighted = true;
				}
			}
		} else {
			if (isHighlighted) {
				go.GetComponent<Renderer> ().material.color = Color.blue;
				isHighlighted = false;
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

	}*/
}
