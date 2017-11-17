using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterBarrier : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit (Collider coll) {
		//if (coll.gameObject.tag == "Fire") {
			//Debug.Log ("Exited some collider");
			GameObject go = coll.gameObject;
			Destroy (go);
		//}
	}
}
