using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour {

	//bool isHighlighted = false;
	//bool isHighlightedRed = false;
	public Material mat1;
	public Material mat2;
	public Material mat3;
	public GameObject cs;
	public GameObject br;
	public GameObject r;
	public static Transform triggeredAOSLocation;
	public static GameObject go;
	GameObject go2;
	//bool isActiveObject = false;
	public GameObject activeObjectHolder;
	string stringGOToBeActivated;
	public static bool manaDepleted = false;
	//public static int[] activeAO = new bool[3] { false, false, false };
	public static int activeAO = 0;
	//public GameObject[] goao;
	//int counter = 0;

	// Use this for initialization
	void Start () {
		cs.GetComponent<Renderer> ().material = mat1;
		br.GetComponent<Renderer> ().material = mat1;
		r.GetComponent<Renderer> ().material = mat1;
		activeAO = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (manaDepleted) {
			foreach (Transform child in activeObjectHolder.transform) {
				child.gameObject.SetActive (false);
			}
			activeAO = 0;
			manaDepleted = false;
		}

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				go = hit.collider.gameObject;
				stringGOToBeActivated = go.name;
				if (go.CompareTag ("ActiveObject") && go.GetComponent<Renderer> ().material.name == "Orange (Instance)") {
					if ((Mana.mana - 20) > 1) { 
						go.GetComponent<Renderer> ().material = mat2;
						activeAO += 1;
						foreach (Transform child in activeObjectHolder.transform)
							if (child.CompareTag (stringGOToBeActivated))
								child.gameObject.SetActive (true);
						Mana.slashMana (20);
					} else if ((Mana.mana - 20) < 1)
						go.GetComponent<Renderer> ().material = mat3;
					
				} else if (go.CompareTag ("ActiveObject") && go.GetComponent<Renderer> ().material.name == "Light Green (Instance)") {
					go.GetComponent<Renderer> ().material = mat1;
					activeAO -= 1;
					foreach (Transform child in activeObjectHolder.transform)
						if (child.CompareTag (stringGOToBeActivated))
							child.gameObject.SetActive (false);
				} else if (go.CompareTag ("ActiveObject") && go.GetComponent<Renderer> ().material.name == "Red (Instance)") {
					go.GetComponent<Renderer> ().material = mat1;
				}
			}
		}
	}
}
		/*
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (!isHighlighted) {
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					go = hit.collider.gameObject;
					if (go.CompareTag ("ActiveObject")) {
						if ((Mana.mana - 30) > 1) { 
							stringGOToBeActivated = go.name;
							go.GetComponent<Renderer> ().material = mat2;
							isHighlighted = true;
							//isActiveObject = true;
							//go2 = activeObjectHolder.transform.Find (stringGOToBeActivated).gameObject;
                              
							activeAO += 1;


							if (stringGOToBeActivated == "coiled_spring")
								activeAO [0] = true;
							else if (stringGOToBeActivated == "ramp")
								activeAO [1] = true;
							else if (stringGOToBeActivated == "bridge_ramp")
								activeAO [2] = true;
							
							foreach (Transform child in activeObjectHolder.transform) {
								if(child.CompareTag(stringGOToBeActivated)) {
									child.gameObject.SetActive(true);
									//child.gameObject.GetComponent<Renderer>().enabled = true;
									//child.gameObject.GetComponent<MeshCollider> ().enabled = true;
								}
							}

							//if (Mana.manaRegenPerSec == 1f)
							//	Mana.manaRegenPerSec = -.25f;
							//else
							//	Mana.manaRegenPerSec += -0.25f;
							//


							if(Mana.manaRegenPerSec < 0) {
								Mana.manaRegenPerSec -= 0.25f;
							} else if (Mana.manaRegenPerSec > 0 ) {
								Mana.manaRegenPerSec = -0.25f;
							}


							Mana.slashMana(30);
						} else if ((Mana.mana - 30) < 1) {
							stringGOToBeActivated = go.name;
							go.GetComponent<Renderer> ().material = mat3;
							isHighlighted = true;
							isHighlightedRed = true;
						}
						//StartCoroutine (refreshAWhile ());
					}
				}
				//if(isActiveObject)
					//ActiveObjectSpawner.spawnObject (go);
			} else if (isHighlighted) {
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					go = hit.collider.gameObject;
					if (go.tag == "ActiveObject") {
						stringGOToBeActivated = go.name;
						go.GetComponent<Renderer> ().material = mat1;
						isHighlighted = false;
						//isActiveObject = true;
						//go2 = activeObjectHolder.transform.Find (stringGOToBeActivated).gameObject;
						//go2.SetActive(false);
						if (!isHighlightedRed) {
							activeAO -= 1;
							isHighlightedRed = false;
						}

						
						//if (stringGOToBeActivated == "coiled_spring")
						//	activeAO [0] = false;
						//else if (stringGOToBeActivated == "ramp")
						//	activeAO [1] = false;
						//else if (stringGOToBeActivated == "bridge_ramp")
						//	activeAO [2] = false;


						foreach (Transform child in activeObjectHolder.transform) {
							if (child.CompareTag (stringGOToBeActivated)) {
								child.gameObject.SetActive (false);
							}
						}
					}
				}
				//if(isActiveObject)
					//ActiveObjectSpawner.spawnObject (new GameObject());
			}
		}
	}
	*/
