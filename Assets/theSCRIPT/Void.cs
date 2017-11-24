using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour {

	public Vector3 Axis;
	public float Velocity = 5f;

	// Use this for initialization
	void Start () {
		Axis = new Vector3 (Random.Range (-1f, 1f),
			Random.Range (-1f, 1f), Random.Range (-1f, 1f));
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
