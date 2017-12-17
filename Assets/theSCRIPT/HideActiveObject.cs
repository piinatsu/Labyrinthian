using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideActiveObject : MonoBehaviour {

	public GameObject[] goao;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < goao.Length; i++) {
			Debug.Log ("aaaaaaaa");
			if (goao [i].CompareTag ("coiled_spring")) {
				goao [i].GetComponent<Collider> ().isTrigger = false;
				goao [i].GetComponent<Collider> ().enabled = false;
				goao [i].GetComponent<Renderer> ().enabled = false;
			} else if (goao [i].CompareTag ("ramp") || goao [i].CompareTag ("bridge_ramp")) {
				goao [i].GetComponent<MeshCollider> ().convex = false;
				goao [i].GetComponent<MeshCollider> ().enabled = false;
				goao [i].GetComponent<Renderer> ().enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
