using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLerp : MonoBehaviour {

	Vector3 originalPosition;
	public float speed = 2f;
	public float timer = 1f;
	public Transform pos1;
	public Transform pos2;
	Transform destination;
	public float smoothing = 1f;
	//bool tgtReached = false;

	// Use this for initialization
	void Start () {
		//StartCoroutine (coro (pos1, pos2));
	}

	// Update is called once per frame
	void Update () {
		
		transform.position = Vector3.Lerp 
			(pos1.position, pos2.position, speed * timer);

		if (destination == pos1) {
			timer = Mathf.Clamp (timer - Time.deltaTime, 0.0f, 1.0f / speed);
		} else {
			timer = Mathf.Clamp (timer + Time.deltaTime, 0.0f, 1.0f / speed);
		}
		if (transform.position == pos1.position)
			destination = pos2;
		else if (transform.position == pos2.position)
			destination = pos1;

	}

	/*
	IEnumerator coro (Transform p1, Transform p2) {
		while (Vector3.Distance (transform.position, pos2.position) > 1f) {
			transform.position = Vector3.Lerp (transform.position, pos2.position,
				smoothing * Time.deltaTime);
			yield return null;
			tgtReached = false;
		}

		tgtReached = true;
		if (tgtReached) {
			smoothing *= -1;
		}


		print ("Target Reached");
		yield return new WaitForSeconds (3f);
		print ("Coroutine finished");
	}
	*/
	void OnTriggerEnter(Collider target)
	{
		Debug.Log ("Collision Triggered");
		if (target.tag == "Player") 
		{
			string tgt = target.tag.ToString ();
			Destroy (target.gameObject);
			Debug.Log (tgt + " destroyed");
			//pm.SetActive (true);
			//pl.SetActive (false);
		}
	}
}
