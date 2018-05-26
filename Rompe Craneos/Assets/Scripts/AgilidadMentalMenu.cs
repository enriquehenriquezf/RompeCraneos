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
			if (i < 30) {
				Transform btn = GameObject.Find ("Canvas").transform.GetChild (0).Find ("ButtonLvl (" + i + ")");
				btn.GetComponent<Button> ().interactable = true;
				float w = EstrellasLvl [i] / 5f;
				btn.transform.GetChild (1).GetComponent<RawImage> ().uvRect = new Rect (0f, 0f, w, 1f);
				btn.transform.GetChild (1).localScale = new Vector3 (w / 5f, 0.2f, 1f);
			}
		}
	}

	public void AgilidadMentalTuto()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",4f);
		PlayerPrefs.SetFloat ("finishlvl",30f);
		PlayerPrefs.SetFloat ("deadtime",10f);
		PlayerPrefs.SetInt ("dificultad",0);
		PlayerPrefs.SetInt ("palabras",1);
		PlayerPrefs.SetInt ("nivel",0);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental1()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",9f);
		PlayerPrefs.SetInt ("dificultad",0);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",1);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental2()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",8f);
		PlayerPrefs.SetInt ("dificultad",0);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",2);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental3()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",8f);
		PlayerPrefs.SetInt ("dificultad",0);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",3);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental4()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",7f);
		PlayerPrefs.SetInt ("dificultad",0);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",4);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental5()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",6f);
		PlayerPrefs.SetInt ("dificultad",0);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",5);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental6()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",9f);
		PlayerPrefs.SetInt ("dificultad",1);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",6);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental7()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",8f);
		PlayerPrefs.SetInt ("dificultad",1);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",7);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental8()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",8f);
		PlayerPrefs.SetInt ("dificultad",1);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",8);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental9()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",7f);
		PlayerPrefs.SetInt ("dificultad",1);
		PlayerPrefs.SetInt ("palabras",1);
		PlayerPrefs.SetInt ("nivel",9);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental10()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",7f);
		PlayerPrefs.SetInt ("dificultad",1);
		PlayerPrefs.SetInt ("palabras",1);
		PlayerPrefs.SetInt ("nivel",10);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental11()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",6f);
		PlayerPrefs.SetInt ("dificultad",1);
		PlayerPrefs.SetInt ("palabras",1);
		PlayerPrefs.SetInt ("nivel",11);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental12()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",9f);
		PlayerPrefs.SetInt ("dificultad",2);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",12);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental13()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",8f);
		PlayerPrefs.SetInt ("dificultad",2);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",13);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental14()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",8f);
		PlayerPrefs.SetInt ("dificultad",2);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",14);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental15()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",7f);
		PlayerPrefs.SetInt ("dificultad",2);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",15);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental16()
	{
		PlayerPrefs.SetInt ("vel",4);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",7f);
		PlayerPrefs.SetInt ("dificultad",2);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",16);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental17()
	{
		PlayerPrefs.SetInt ("vel",4);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",6f);
		PlayerPrefs.SetInt ("dificultad",2);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",17);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental18()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",4f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",9f);
		PlayerPrefs.SetInt ("dificultad",3);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",18);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental19()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",4f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",8f);
		PlayerPrefs.SetInt ("dificultad",3);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",19);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental20()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",8f);
		PlayerPrefs.SetInt ("dificultad",3);
		PlayerPrefs.SetInt ("nivel",20);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental21()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",8f);
		PlayerPrefs.SetInt ("dificultad",3);
		PlayerPrefs.SetInt ("palabras",1);
		PlayerPrefs.SetInt ("nivel",21);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental22()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",7f);
		PlayerPrefs.SetInt ("dificultad",3);
		PlayerPrefs.SetInt ("palabras",1);
		PlayerPrefs.SetInt ("nivel",22);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental23()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",6f);
		PlayerPrefs.SetInt ("dificultad",3);
		PlayerPrefs.SetInt ("palabras",2);
		PlayerPrefs.SetInt ("nivel",23);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental24()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",9f);
		PlayerPrefs.SetInt ("dificultad",4);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",24);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental25()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",8f);
		PlayerPrefs.SetInt ("dificultad",4);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",25);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental26()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",8f);
		PlayerPrefs.SetInt ("dificultad",4);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",26);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental27()
	{
		PlayerPrefs.SetInt ("vel",2);
		PlayerPrefs.SetFloat ("spawn",3f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",7f);
		PlayerPrefs.SetInt ("dificultad",4);
		PlayerPrefs.SetInt ("palabras",0);
		PlayerPrefs.SetInt ("nivel",27);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental28()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",2f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",7f);
		PlayerPrefs.SetInt ("dificultad",4);
		PlayerPrefs.SetInt ("palabras",2);
		PlayerPrefs.SetInt ("nivel",28);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void AgilidadMental29()
	{
		PlayerPrefs.SetInt ("vel",3);
		PlayerPrefs.SetFloat ("spawn",1f);
		PlayerPrefs.SetFloat ("finishlvl",60f);
		PlayerPrefs.SetFloat ("deadtime",6f);
		PlayerPrefs.SetInt ("dificultad",4);
		PlayerPrefs.SetInt ("palabras",2);
		PlayerPrefs.SetInt ("nivel",29);
		PlayerPrefs.SetInt ("nivelMax",nivel);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMental");
	}
	public void Regresar()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Menu");
		PlayerPrefs.SetString ("Save", "False");
		PlayerPrefs.SetString ("Load", "False");
	}
	public void Unlock()
	{
		for (int i = 0; i <= 29; i++) {
			Transform btn = GameObject.Find ("Canvas").transform.GetChild (0).Find ("ButtonLvl (" + i + ")");
			btn.GetComponent<Button> ().interactable = true;
			float w = EstrellasLvl [i] / 5f;
			btn.transform.GetChild (1).GetComponent<RawImage> ().uvRect = new Rect(0f,0f,w,1f);
			btn.transform.GetChild (1).localScale = new Vector3(w/5f,0.2f,1f);
		}
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