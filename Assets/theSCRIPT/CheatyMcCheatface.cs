using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatyMcCheatface : MonoBehaviour {

	public GameObject thePlayer;
	public GameObject coiledSpringPos;
	public GameObject bridgeRampPos;
	public GameObject rampPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void thePlayerInvincibility() {
		if (thePlayer.CompareTag ("Player")) {
			thePlayer.tag = "Invincible";
		} else if (thePlayer.CompareTag ("Invincible")) {
			thePlayer.tag = "Player";
		}
	}

	public void thousandMana () {
		Mana.mana = 1000;
	}

	public void manaPlusPlus () {
		Mana.mana += 20;
	}

	public void spawnNearCoiledSpring () {
		thePlayer.transform.position = coiledSpringPos.transform.position;
	}

	public void spawnNearBridgeRamp () {
		thePlayer.transform.position = bridgeRampPos.transform.position;
	}

	public void spawnNearRamp () {
		thePlayer.transform.position = rampPos.transform.position;
	}
}
