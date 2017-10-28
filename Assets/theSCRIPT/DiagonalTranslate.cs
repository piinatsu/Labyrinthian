using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalTranslate : MonoBehaviour {

	public Vector3 v3;
	public float speed;
	RaycastHit hit;
	public float raycastdist;

	// Use this for initialization
	void Start () {
		//v3 = new Vector3 (0, 0, 0);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (speed * v3 * Time.deltaTime);
		//transform.Translate (Mathf.Sin (30) * Time.deltaTime, 0, 0);
		//Debug.Log (Mathf.Sin (30) * Time.deltaTime);
		//transform.Translate (2* Time.deltaTime, 0, 0);

		if (Physics.Raycast (transform.position, 
			transform.TransformDirection(Vector3.forward), 
			out hit, raycastdist)) {
			speed *= -1f;
		}
		if (Physics.Raycast (transform.position, 
			transform.TransformDirection(Vector3.back), 
			out hit, raycastdist)) {
			speed *= -1f;
		}

		Debug.DrawLine (transform.position, hit.point, Color.red);
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
