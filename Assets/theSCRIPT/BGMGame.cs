using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMGame : MonoBehaviour {

	void Awake () {
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("BGMGame");
		if (objs.Length > 1) {
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
