using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBump : MonoBehaviour {
	public AudioClip[] bump;
	public AudioSource source;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision other) {
		//if (coll.gameObject.tag == "Player") {
		if (other.collider.CompareTag("Player")) {
			//float vol = Random.Range (0.5f, 1.0f);
			int b = Random.Range(0, bump.Length);
			if (other.relativeVelocity.magnitude > 4f) {
				source.PlayOneShot (bump[b], 1.0f);
			} else if (other.relativeVelocity.magnitude > 3f) {
				source.PlayOneShot (bump[b], 0.5f);
			} else if (other.relativeVelocity.magnitude > 1f) {
				source.PlayOneShot (bump[b], 0.2f);
			}
		}
	}
}
