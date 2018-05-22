using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class AgilidadMentalMenu : MonoBehaviour {
	public int puntos;
	public int nivel;
	public static AgilidadMentalMenu AM_Menu;

	void Awake(){
		if (AM_Menu == null) {
			AM_Menu = this;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.Score = puntos;
		data.nivel = nivel;
		GameObject.FindGameObjectsWithTag ("Boton")[1].GetComponent<Button> ().interactable = true;// TODO: arreglar botones de lvls

		bf.Serialize (file,data);
		file.Close ();
	}

	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			puntos = data.Score;
			nivel = data.nivel;
		}
	}

	public void AgilidadMentalTuto()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",2f);
		int vel = PlayerPrefs.GetInt ("vel");
		float spawn = PlayerPrefs.GetFloat("spawn");
	}
}


[Serializable]
class PlayerData
{
	public int Score;
	public int nivel;
}