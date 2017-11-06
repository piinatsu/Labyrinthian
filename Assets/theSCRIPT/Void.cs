using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour {

	public Vector3 Axis;
	public float Velocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Axis * Velocity * Time.deltaTime);
	}

	void OnTriggerEnter(Collider target) {
		if (target.tag == "Player")
			Destroy (target.gameObject);
	}
}
