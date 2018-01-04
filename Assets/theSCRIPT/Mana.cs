using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour {

	public static float mana;
	public static float manaRegenPerSec;
	public static bool canRegen = true;
	public Slider manaSlider;
	public Text manaText;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("manaRegen", 0.5f, 1.1f);
		mana = manaSlider.value;
		manaRegenPerSec = 1.0f;
	}

	// Update is called once per frame
	void Update () {

	}
		
	void manaRegen () {
		manaText.text = mana.ToString ();
		manaSlider.value = mana;
		//if (canRegen) {
		if (mana < 100) {
			mana += manaRegenPerSec;
			if (mana < 2.0f) {
				PlayerBall.manaDepleted = true;
				Highlight.manaDepleted = true;
			}
			//manaText.text = mana.ToString ();
			//manaSlider.value = mana;

			//}
		}
		//Debug.Log (manaRegenPerSec);
	}

	public static void slashMana (int amount) {
		mana -= amount;
	}
/*
	public void shallNotRegen () {
		canRegen = false;
	}
*/

	/*
	IEnumerator drainManaToScore () {
		while (mana > 0) {

		}
	}
	*/
}
