using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrolRaycast : MonoBehaviour {

	public Vector3 velocity;
	Vector3 originalPosition;
	//public float distance = 5f;
	public float speed = 5f;
	//public float distFromStart;
	bool isGoingLeft;
	RaycastHit hit;
	public float raycastdist = 1f;

	// Use this for initialization
	void Start () {
		//gameObject.transform.position.x = speed;
		originalPosition = transform.position;
		//transform = GetComponent<Transform> ();
		velocity = new Vector3 (speed, 0, 0);
		transform.Translate (velocity.x*Time.deltaTime, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		velocity = new Vector3 (speed, 0, 0);
		//distFromStart = transform.position.x - originalPosition.x;
		transform.Translate (velocity.x * Time.deltaTime, 0, 0);
		//transform.localPosition += Vector3.right * Time.deltaTime;
		//Vector3 fwd = transform.TransformDirection(Vector3.forward);

		//Debug.Log (speed);

		if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.right), out hit, raycastdist)) {
			//print ("There is something in front of the object!");
			//transform.Translate (-velocity.x * Time.deltaTime, 0, 0);
			//velocity = -velocity;
			speed = -speed;
		}
		if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.left), out hit, raycastdist)) {
			//print ("There is something behind the object!");
			//transform.Translate (velocity.x * Time.deltaTime, 0, 0);
			speed = Mathf.Abs(speed);
		}

		Debug.DrawLine (transform.position, hit.point, Color.red);
		//Debug.DrawLine (ray.origin, hit.point, Color.red);
		//Debug.DrawLine (transform.position, new Vector3(0.5f,0,0), Color.red);

		/*if (isGoingLeft)
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

	void SwitchDirection()
	{
		isGoingLeft = !isGoingLeft;
		//TODO: Change facing direction, animation, etc
	}
}
