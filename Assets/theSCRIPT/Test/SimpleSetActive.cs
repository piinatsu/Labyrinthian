using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSetActive : MonoBehaviour {

	public GameObject go;
	bool a = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void activator () {
		if (!a) {
			go.SetActive (true);
			a = true;
		} else if (a) {
			go.SetActive (false);
			a = false;
		}
	}
}
