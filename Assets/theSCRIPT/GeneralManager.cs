using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour {

	public GameObject theCam;
	public GameObject theWall;
	public GameObject thePlayer;

	public static bool wallCollisionDisable = false;

	//GameObject dialogManagerCanvas;

	// Use this for initialization
	void Start () {
		StartCoroutine(rotateWorld(0.5f));
		//dialogManagerCanvas = DialogManager.FindGameObjec
	}

	IEnumerator rotateWorld(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		//theCam.transform.rotation = Quaternion.Euler(0, 30, 0);

		//Vector3 temp = transform.rotation.eulerAngles;
		//temp.z = 70.0f;
		theCam.transform.rotation = Quaternion.Euler(90, 0, 0);
	}
	/*
	public static void toggleWallMesh (bool fag) {
		if (fag)
			theWall.
	}
	*/
	// Update is called once per frame
	void Update () {
		//tpgo = go.transform.position;
		//tpgo = go.transform.rotation.eulerAngles;
		//Debug.Log (tpgo);
		//Physics.IgnoreCollision

		if (wallCollisionDisable) {
			//print ("mesh off, please");
			if (theWall.GetComponent<MeshCollider> ().enabled) {
				//print ("mesh collider is on turning off now");
				theWall.GetComponent<MeshCollider> ().enabled = false;
			}
		}
		else if (!wallCollisionDisable) {
			//print ("mesh on, please");
			if (!theWall.GetComponent<MeshCollider> ().enabled) {
				//print ("mesh collider is off turning on now");
				theWall.GetComponent<MeshCollider> ().enabled = true;
			}
		}
	}
}
