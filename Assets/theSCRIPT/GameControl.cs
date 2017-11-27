using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public int lastScene;
	public string lastSceneString;
	public Vector3 playerLastPosition;

	// Use this for initialization
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
	}

	public void Save(int a, float x, float y, float z) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + 
			"/playerLastInfo.dat");

		LastData data = new LastData ();
		data.lastScene = a;
		data.playerLastPositionX = x;
		data.playerLastPositionY = y;
		data.playerLastPositionZ = z;
		//playerLastPosition = new Vector3 (x, y, z);
		//data.playerLastPosition = playerLastPosition;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load ()
	{
		if (File.Exists (Application.persistentDataPath +
		   "/playerLastInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath +
				"/playerLastInfo.dat", FileMode.Open);
			LastData data = (LastData) bf.Deserialize (file);
			file.Close ();

			lastScene = data.lastScene;
			playerLastPosition = new Vector3 (
				data.playerLastPositionX,
				data.playerLastPositionY,
				data.playerLastPositionZ);
			//playerLastPosition = data.playerLastPosition;
		}
	}
}

[Serializable]
class LastData {
	public int lastScene;
	public string lastSceneString;
	public float playerLastPositionX;
	public float playerLastPositionY;
	public float playerLastPositionZ;
	//public Vector3 playerLastPosition;
}
