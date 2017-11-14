using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R9 : MonoBehaviour {

	public GameObject theCam;

	// Use this for initialization
	void Start () {
		StartCoroutine(Rotate(0.5f));
	}

	IEnumerator Rotate(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		//theCam.transform.rotation = Quaternion.Euler(0, 30, 0);

		//Vector3 temp = transform.rotation.eulerAngles;
		//temp.z = 70.0f;
		theCam.transform.rotation = Quaternion.Euler(90, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
