using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectSpawner : MonoBehaviour {
	public GameObject ramp;
	public GameObject bridgeRamp;
	public GameObject coiledSpring;
	public static Transform thisAOSLocation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider coll) {
		//Spawn.aos = this;
		//Debug.Log(this.gameObject.transform);
		thisAOSLocation = this.gameObject.transform;
		//Spawn.triggeredAOSLocation = thisAOSLocation;
		//Highlight.triggeredAOSLocation = thisAOSLocation;
	}

	void OnTriggerExit (Collider coll) {
		//Spawn.aos = null;

		//Spawn.triggeredAOSLocation = null;
		//Highlight.triggeredAOSLocation = null;
	}

	public static void spawnObject (GameObject go) {
		//Instantiate (go, a, b);
		//Destroy(this.gameObject);
		Instantiate(go, thisAOSLocation.transform.position, 
			thisAOSLocation.transform.rotation);
	}
}
