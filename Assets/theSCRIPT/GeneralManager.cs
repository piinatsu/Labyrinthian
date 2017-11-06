using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour {

	public GameObject theCam;

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
	
	// Update is called once per frame
	void Update () {
		//tpgo = go.transform.position;
		//tpgo = go.transform.rotation.eulerAngles;
		//Debug.Log (tpgo);
	}
}
