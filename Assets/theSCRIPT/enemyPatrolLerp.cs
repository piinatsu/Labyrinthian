using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrolLerp : MonoBehaviour {

	Vector3 originalPosition;
	public float speed = 2f;
	public float timer = 1f;
	public Transform position1;
	public Transform position2;
	public Transform destination;

	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (position1.position, position2.position, speed * timer);

		if (destination == position1) {
			timer = Mathf.Clamp (timer - Time.deltaTime, 0.0f, 1.0f / speed);
		} else {
			timer = Mathf.Clamp (timer + Time.deltaTime, 0.0f, 1.0f / speed);
		}
	}

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
