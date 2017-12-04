using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour {

	//public Text manaText;
	public static float mana;
	public static float manaRegenPerSec;
	public static bool canRegen = true;
	public Slider manaSlider;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("manaRegen", 1.0f, 1.0f);
		mana = manaSlider.value;
	}

	// Update is called once per frame
	void Update () {

	}
		
	void manaRegen () {
		if (canRegen) {
			mana += manaRegenPerSec;
			//manaText.text = mana.ToString ();
			manaSlider.value = mana;
		}
	}

	public void shallNotRegen () {
		canRegen = false;
	}

	public static void slashMana (int amount) {
		mana -= amount;
	}
	/*
	IEnumerator drainManaToScore () {
		while (mana > 0) {

		}
	}
	*/
}
