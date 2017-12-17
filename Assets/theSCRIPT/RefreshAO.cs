using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshAO : MonoBehaviour {

	public GameObject[] goao;
	int counter = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine (refreshAWhile ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator refreshAWhile () {
		while (counter < 5) {
			Debug.Log ("AUOUOUOUOUO");
			for (int i = 0; i < goao.Length; i++) {
				if (goao [i].CompareTag ("coiled_spring")) {
					goao [i].GetComponent<Collider> ().isTrigger = false;
					goao [i].GetComponent<Collider> ().enabled = false;
					goao [i].GetComponent<Collider> ().enabled = true;
					goao [i].GetComponent<Collider> ().isTrigger = true;
				} else if (goao [i].CompareTag ("ramp") || goao [i].CompareTag ("bridge_ramp")) {
					goao [i].GetComponent<MeshCollider> ().convex = false;
					goao [i].GetComponent<MeshCollider> ().enabled = false;
					goao [i].GetComponent<MeshCollider> ().enabled = true;
					goao [i].GetComponent<MeshCollider> ().convex = true;
				}
			}
			counter++;
			yield return new WaitForSecondsRealtime (2.0f);
		}
	}
}
