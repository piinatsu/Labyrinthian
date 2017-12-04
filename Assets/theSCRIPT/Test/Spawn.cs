using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	public GameObject thego;
	public static ActiveObjectSpawner aos;
	public static Transform triggeredAOSLocation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void instgo () {
		Instantiate (thego, triggeredAOSLocation.transform.position,
			triggeredAOSLocation.transform.rotation);

	}
}
