using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterSpawn : MonoBehaviour {

	public GameObject[] theAster;
	//public Rigidbody[] theAster;
	//public GameObject spawnPos1;
	//public GameObject spawnPos2;
	public Transform[] spawnPos;
	//public Transform theParent;

	// Use this for initialization
	void Start () {
		//StartCoroutine(spawnAsters(1f));
		InvokeRepeating ("spawnAster", 3.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spawnAster() {
		int rng = Mathf.FloorToInt((Random.value * 4));
		int rngAster = Mathf.FloorToInt((Random.value * 3));
		/*
		Rigidbody asterClone = (Rigidbody)Instantiate 
			(theAster[rngAster], spawnPos[rng].transform.position, 
				Quaternion.Euler(new Vector3 
				(Random.value*360, 0, Random.value*360)));
				*/
		GameObject asterClone = (GameObject)Instantiate 
			(theAster[rngAster], spawnPos[rng].transform.position, 
				Quaternion.Euler(new Vector3 
					(Random.value*360, Random.value*360, Random.value*360)));
		asterClone.transform.localScale *= 50f;
		asterClone.GetComponent<Rigidbody>().AddRelativeForce
		(new Vector3(Random.value, Random.Range(-1, 1), Random.value) * 
			Mathf.Clamp((Random.value * 25), 15, 25), ForceMode.Impulse);
		asterClone.GetComponent<Rigidbody>().AddRelativeTorque
		(new Vector3(Random.Range(10,100), Random.Range(10,100), 
			Random.Range(10,100)));
		Destroy (asterClone, Mathf.Clamp((Random.value * 30), 20, 30));
	}

	IEnumerator spawnAsters(float waitTime) {
		for (;;) {
			int rng = Mathf.FloorToInt ((Random.value * 4));
			int rngAster = Mathf.FloorToInt ((Random.value * 3));
			/*
		Rigidbody asterClone = (Rigidbody)Instantiate 
			(theAster[rngAster], spawnPos[rng].transform.position, 
				Quaternion.Euler(new Vector3 
				(Random.value*360, 0, Random.value*360)));
				*/
			GameObject asterClone = (GameObject)Instantiate 
			(theAster [rngAster], spawnPos [rng].transform.position, 
				                       Quaternion.Euler (new Vector3 (Random.value * 360, Random.value * 360, Random.value * 360)));
			asterClone.GetComponent<Rigidbody> ().AddRelativeForce
		(new Vector3 (Random.value, Random.Range (-1, 1), Random.value) *
			Mathf.Clamp ((Random.value * 25), 15, 25), ForceMode.Impulse);
			asterClone.GetComponent<Rigidbody> ().AddRelativeTorque
		(new Vector3 (Random.Range (10, 100), Random.Range (10, 100), 
				Random.Range (10, 100)));
			Destroy (asterClone, Mathf.Clamp ((Random.value * 30), 20, 30));
			yield return new WaitForSeconds (waitTime);
		}
	}
}
