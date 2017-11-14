using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoiledSpring : MonoBehaviour {

	bool isColliding = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider coll) {
		//GameObject go = coll.gameObject;
		if (!isColliding) {
			isColliding = true;
			if (coll.gameObject.tag == "Player") {
				Rigidbody rb = coll.gameObject.GetComponent<Rigidbody> ();
				//rb.velocity = new Vector3 (0, 50, 0);
				rb.AddForce (new Vector3 (0, 750, 0), ForceMode.Force);
			}
		}
	}

	void OnTriggerExit (Collider coll) {
		if (isColliding) {
			isColliding = false;
		}
	}
}
