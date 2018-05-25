using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class AgilidadMentalMenu : MonoBehaviour {
	public int puntos;
	public int puntosActual;
	public Text Points;
	public int nivelActual;
	public int[] puntosLvl = new int[30];
	public int[] EstrellasLvl = new int[30];
	public int nivel;
	public int estrellas;
	public static AgilidadMentalMenu AM_Menu;

	void Awake(){
		if (AM_Menu == null) {
			AM_Menu = this;
		}
	}
	// Use this for initialization
	void Start () {
		puntos = PlayerPrefs.GetInt ("Score");
		puntosActual = PlayerPrefs.GetInt ("ScoreActual");
		estrellas = PlayerPrefs.GetInt ("Estrellas");
		nivel = PlayerPrefs.GetInt ("Nivel");
		nivelActual = PlayerPrefs.GetInt ("NivelActual");
		if (PlayerPrefs.GetString ("Save").Equals ("True")) {
			Save ();
			PlayerPrefs.SetString ("Save","False");
		}
		else if (PlayerPrefs.GetString ("Load").Equals ("True")) {
			Load ();
			PlayerPrefs.SetString ("Load","False");
		}
		Points.text = "Puntos: " + puntos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		int p = 0;
		if (File.Exists (Application.persistentDataPath + Path.DirectorySeparatorChar + "playerInfo.dat")) {
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			List<PlayerData> DataCollection = (List<PlayerData>)bf.Deserialize (file);
			//PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();
			for (int i = 0; i < DataCollection.Count; i++) {
				PlayerData data = DataCollection [i];
				puntosLvl[i] = data.ScoreLvl;
				EstrellasLvl[i] = data.Estrellas;
			}
		}
		FileStream file2 = File.Open (Application.persistentDataPath + Path.DirectorySeparatorChar +"playerInfo.dat", FileMode.OpenOrCreate);
		if (puntos > puntosLvl [nivelActual]) {
			puntosLvl [nivelActual] = puntos;
		}
		if (estrellas > EstrellasLvl [nivelActual]) {
			EstrellasLvl [nivelActual] = estrellas;
		}
		List<PlayerData> DataCollection2 = new List<PlayerData>();
		for (int i = 0; i < puntosLvl.Length; i++) {
			PlayerData data2 = new PlayerData ();
			p = p + puntosLvl[i];
			data2.Score = p;
			data2.nivel = nivel;
			data2.ScoreLvl = puntosLvl[i];
			data2.Estrellas = EstrellasLvl[i];
			DataCollection2.Add (data2);
		}
		puntos = p;
		ActualizarNiveles ();

		bf.Serialize (file2,DataCollection2);
		file2.Close ();
	}

	public void Load(){
		if (File.Exists (Application.persistentDataPath + Path.DirectorySeparatorChar +"playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			List<PlayerData> DataCollection = (List<PlayerData>)bf.Deserialize (file);
			//PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();
			for (int i = 0; i < DataCollection.Count; i++) {
				PlayerData data = DataCollection [i];
				puntos = data.Score;
				nivel = data.nivel;
				puntosLvl[i] = data.ScoreLvl;
				EstrellasLvl[i] = data.Estrellas;				
			}
			ActualizarNiveles ();
		}
	}

	void ActualizarNiveles()
	{
		for (int i = 0; i <= nivel; i++) {
			Transform btn = GameObject.Find ("Canvas").transform.GetChild (0).Find ("ButtonLvl (" + i + ")");
			btn.GetComponent<Button> ().interactable = true;
			float w = EstrellasLvl [i] / 5f;
			btn.transform.GetChild (1).GetComponent<RawImage> ().uvRect = new Rect(0f,0f,w,1f);
			btn.transform.GetChild (1).localScale = new Vector3(w/5f,0.2f,1f);
		}
	}

	public void AgilidadMentalTuto()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",30f);
		PlayerPrefs.SetFloat ("deadtime",9f);
		PlayerPrefs.SetInt ("nivel",0);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental1()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",8f);
		PlayerPrefs.SetInt ("nivel",1);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental2()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",7f);
		PlayerPrefs.SetInt ("nivel",2);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental3()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",7f);
		PlayerPrefs.SetInt ("nivel",3);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental4()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",6f);
		PlayerPrefs.SetInt ("nivel",4);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental5()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",6f);
		PlayerPrefs.SetInt ("nivel",5);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental6()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",1f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",8f);
		PlayerPrefs.SetInt ("nivel",6);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
}


[Serializable]
class PlayerData
{
	public int Score;
	public int nivel;
	public int ScoreLvl;
	public int Estrellas;
}