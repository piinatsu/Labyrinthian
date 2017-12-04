using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {
	
	public static GlobalVariables Glovar;

	public static string originScene;

	void Awake () {
		if (Glovar == null) {
			DontDestroyOnLoad (gameObject);
			Glovar = this;
		} else if (Glovar != this) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
