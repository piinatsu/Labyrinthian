using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterSpawn : MonoBehaviour {

	public Rigidbody theAster;
	public GameObject spawnPos1;
	public GameObject spawnPos2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spawnAster() {
		Rigidbody asterClone = (Rigidbody)Instantiate 
			(theAster, spawnPos1.transform.position, 
				Quaternion.Euler(new Vector3 
				(Random.value*360, 0, Random.value*360)));
		asterClone.AddForce(transform.forward * Random.value *50);
		Destroy (asterClone, Mathf.Clamp((Random.value * 20), 10, 20));
	}
}
