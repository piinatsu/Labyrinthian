using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRaycast : MonoBehaviour {

	Vector3 velocity;
	//Vector3 originalPosition;
	//public float distance = 5f;
	public float speed = 5.0f;
	//public float distFromStart;
	bool isGoingLeft;
	RaycastHit hit;
	public float raycastdist = 1.0f;
	public string hOrV = "Horizontal";
	Ray ray;

	// Use this for initialization
	void Start () {
		//gameObject.transform.position.x = speed;
		//originalPosition = transform.position;
		//transform = GetComponent<Transform> ();

		//velocity = new Vector3 (speed, 0, 0);
		//transform.Translate (velocity.x*Time.deltaTime, 0, 0);

		if (hOrV == "Horizontal")
			velocity = new Vector3 (1, 0, 0);
		else if (hOrV == "Vertical")
			velocity = new Vector3 (0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		//velocity = new Vector3 (speed, 0, 0);
		//transform.Translate (velocity.x * Time.deltaTime, 0, 0);

		transform.Translate (velocity * Time.deltaTime * speed);

		//distFromStart = transform.position.x - originalPosition.x;

		//transform.localPosition += Vector3.right * Time.deltaTime;
		//Vector3 fwd = transform.TransformDirection(Vector3.forward);

		//Debug.Log (speed);
		if (hOrV == "Horizontal") {
			if (Physics.Raycast (transform.position, 
				    transform.TransformDirection (Vector3.right), 
				    out hit, raycastdist)) {
				//print ("There is something in front of the object!");
				//transform.Translate (-velocity.x * Time.deltaTime, 0, 0);
				//velocity = -velocity;
				//speed = -speed;
				speed *= -1f;
			}
			if (Physics.Raycast (transform.position, 
				    transform.TransformDirection (Vector3.left), 
				    out hit, raycastdist)) {
				//print ("There is something behind the object!");
				//transform.Translate (velocity.x * Time.deltaTime, 0, 0);
				//speed = Mathf.Abs(speed);
				speed *= -1f;
			}
		} else if (hOrV == "Vertical") {
			if (Physics.Raycast (transform.position, 
				transform.TransformDirection (Vector3.forward), 
				    out hit, raycastdist)) {
				speed *= -1f;
			}
			if (Physics.Raycast (transform.position, 
				    transform.TransformDirection (Vector3.back), 
				    out hit, raycastdist)) {
				speed *= -1f;
			}
		}
		Debug.DrawLine (transform.position, hit.point, Color.red);
		//Debug.DrawLine (transform.position, new Vector3(0.5f,0,0), Color.red);

		/*
		 * if (isGoingLeft)
		{ 
			// If gone too far, switch direction
			if (distFromStart < -distance)
				SwitchDirection();

			transform.Translate (-velocity.x * Time.deltaTime, 0, 0);
		}
		else
		{
			// If gone too far, switch direction
			if (distFromStart > distance)
				SwitchDirection();

			transform.Translate (velocity.x * Time.deltaTime, 0, 0);
		}*/
	}

	void OnTriggerEnter(Collider target) {
		string playerMat = target.gameObject.
			GetComponent<Renderer> ().material.name;
		string enemyMat = gameObject.
			GetComponent<Renderer> ().material.name;
		if (target.tag == "Player") {
			if (enemyMat == "Red (Instance)" && 
				playerMat == "WoodSurface (Instance)") {
				Destroy (target.gameObject);
			} else if (enemyMat == "Yellow (Instance)" && 
				playerMat == "MetalSurface (Instance)") {
				Destroy (target.gameObject);
			}
		}

	}
}
