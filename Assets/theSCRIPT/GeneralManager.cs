using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour {

	//public static GeneralManager genma;

	public GameObject theCam;
	public GameObject theWall;
	public GameObject thePlayer;
	public int theScore = 1000;
	public GameObject startPosition;

	public static bool isContinueLast = false;
	public static bool wallCollisionDisable = false;
	//Rigidbody rb;

	//GameObject dialogManagerCanvas;

	// Use this for initialization
	void Start () {
		StartCoroutine(rotateWorld(0.5f));
		InvokeRepeating ("scoring", 3f, 1f);
		//dialogManagerCanvas = DialogManager.FindGameObjec
		//rb = thePlayer.GetComponent<Rigidbody>();
		Invoke ("transformLocalPosition", 1.0f);
		thePlayer.transform.localPosition = startPosition.transform.localPosition;
	}

	void transformLocalPosition () {
		if (isContinueLast == true) {
			thePlayer.transform.localPosition = 
				SaveLoadManager.saloma.playerLastPosition;
			isContinueLast = false;
		}
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

	void scoring () {
		theScore -= 3;
		print (theScore);
	}

	public void skillScoring (int skillPenalty) {
		theScore -= skillPenalty;
		print (theScore);
	}

	/*
	public void increaseMass () {
		rb.mass += 1f;
	}

	public void decreaseMass () {
		if (rb.mass >= 2)
			rb.mass -= 1f;
	}
	*/
}
