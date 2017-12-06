using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterBarrier : MonoBehaviour {
	public SoundManager soma;
	public MenuManager menma;
	public AudioSource ausrc;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit (Collider coll) {
		//if (coll.gameObject.tag == "Fire") {
			//Debug.Log ("Exited some collider");
			GameObject go = coll.gameObject;
		if (go.CompareTag ("Player")) {
			ausrc.Play ();
			//soma.deathSound ();
			Destroy (go);
			menma.deathPause ();
		} else {
			Destroy (go);
		}
		//}
	}
}
