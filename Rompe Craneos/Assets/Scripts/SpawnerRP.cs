using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerRP : MonoBehaviour {
	public GameObject fosforo;
	public GameObject PanelFinish;
	public GameObject Stars;
	public GameObject Spawner;
	public GameObject timer;
	public GameObject puntaje;
	GameObject[] go;
	float time = 0f;
	float delta = 0f;
	float finishtime = 0f;
	public float finishlvl = 60f;
	public int nivel = 0;
	public int nivelActual = 0;
	int puntos;
	int estrellas = 0;
	bool finished = false;
	public int CantPalitos;
	public string palitos;
	public string win;
	public int UltimoSpawn;
	string[] wins;
	bool gano = false;
	// Use this for initialization
	void Start () {
		finishlvl = PlayerPrefs.GetFloat("finishlvlRP");
		nivelActual = PlayerPrefs.GetInt ("nivelRP");
		nivel = PlayerPrefs.GetInt ("nivelMaxRP");
		CantPalitos = PlayerPrefs.GetInt ("Palitos");
		palitos = PlayerPrefs.GetString ("Palito");
		UltimoSpawn = PlayerPrefs.GetInt ("UltimoSpawn");
		win = PlayerPrefs.GetString ("Win");
		wins = win.Split (';');
		Time.timeScale = 1f;
		timer.GetComponent<Text> ().text = "Tiempo: " +(int)finishlvl;
		string[] s = palitos.Split(',');
		go = new GameObject[s.Length];
		/*for(int i = 0; i < 4; i++){
			Spawner.transform.GetChild (UltimoSpawn-7+(2*i)).GetComponent<GameObject>().SetActive (false);
		}
		for (int i = UltimoSpawn + 1; i < 44; i++) {
			Spawner.transform.GetChild (i).GetComponent<GameObject>().SetActive (false);
		}*/
		for (int i = 0; i < s.Length; i++) {
			go[i] = (GameObject)Instantiate(fosforo,Spawner.transform);
			go[i].GetComponent<RectTransform>().localPosition = Spawner.transform.GetChild (int.Parse(s[i])).GetComponent<RectTransform>().localPosition;
			go[i].GetComponent<RectTransform>().localRotation = Spawner.transform.GetChild (int.Parse(s[i])).GetComponent<RectTransform>().localRotation;
			go[i].GetComponent<ResolverProblemas> ().SetPos (int.Parse(s[i]));
		}
	}
	
	// Update is called once per frame
	void Update () {
		delta += Time.deltaTime;
		if(delta > 1f)
		{
			time += 1;
			finishtime += 1f;
			delta = 0;
			if (!finished) {
				timer.GetComponent<Text> ().text = "Tiempo: " +(int)(finishlvl - finishtime);
				puntos = (int)(finishlvl - finishtime) * 2;
				puntaje.GetComponent<Text> ().text = "Puntos: " + puntos;
				CheckWin ();
			}
		}
		if (finishtime >= finishlvl && Time.timeScale == 1f && !finished) {
			Time.timeScale = 0f;
			int correctas = 0;
			int i = 0;
			while(i < wins.Length && gano == false)
			{
				string[] W = wins [i].Split (',');
				correctas = 0;
				for(int j = 0; j < go.Length; j++)
				{
					bool sw = false;
					int k = 0;
					while(k < W.Length && sw == false)
					{
						if (go [j].GetComponent<ResolverProblemas> ().GetPos ().Equals(int.Parse(W [k]))) {
							correctas++;
							sw = true;
						}
						k++;
					}
				}
				if (CantPalitos == correctas) {
					gano = true;
				}
				i++;
			}
			int p = puntos;
			float stars = (float)(((float)p / (float)finishtime/ 2f) ) * 5f;
			estrellas = Mathf.FloorToInt(stars);
			if (p < 0) {estrellas = 0;}
			PlayerPrefs.SetInt ("ScoreRP", p);
			PlayerPrefs.SetInt ("ScoreActualRP", p);
			PlayerPrefs.SetInt ("NivelActualRP", nivelActual);
			PlayerPrefs.SetInt ("EstrellasRP", estrellas);
			if (estrellas >= 3 && nivel == nivelActual) {
				nivel = nivel + 1;
			}
			PlayerPrefs.SetInt ("Nivel", nivel);
			string mensaje = "";
			if (estrellas == 5) {mensaje = "Eres Excelente!";}else if(estrellas == 4){mensaje = "Muy Bien!";}else if(estrellas == 3){mensaje = "Felicidades!";}else if(estrellas == 2){mensaje = "Casi lo logras!";}else if(estrellas == 1){mensaje = "Sigue intentandolo!";}else if(estrellas == 0){mensaje = "Debes practicar!";}
			PanelFinish.transform.GetChild (0).GetComponent<Text> ().text = mensaje;
			Stars.GetComponent<RectTransform>().localScale = new Vector3((float)((float)estrellas/10f),0.5f,1f);
			float w = (float)(((float)estrellas / 10f) * 2f);
			Stars.GetComponent<RawImage> ().uvRect = new Rect(0f, 0f, w, 1f);
			finished = true;
			PlayerPrefs.SetString ("Save", "True");
			PanelFinish.SetActive (true);
			PanelFinish.transform.SetAsLastSibling ();
		}
	}

	public void CheckWin(){
		int correctas = 0;
		int i = 0;
		while(i < wins.Length && gano == false)
		{
			string[] W = wins [i].Split (',');
			correctas = 0;
			for(int j = 0; j < go.Length; j++)
			{
				bool sw = false;
				int k = 0;
				while(k < W.Length && sw == false)
				{
					if (go [j].GetComponent<ResolverProblemas> ().GetPos ().Equals(int.Parse(W [k]))) {
						correctas++;
						sw = true;
					}
					k++;
				}
			}
			if (CantPalitos == correctas) {
				gano = true;
			}
			i++;
		}
		if (gano) {
			Time.timeScale = 0f;
			finished = true;
			int p = puntos;
			float stars = (float)(((float)p / (float)finishtime / 2f)) * 5f;
			estrellas = Mathf.FloorToInt (stars);
			if (p < 0) {
				estrellas = 0;
			}
			PlayerPrefs.SetInt ("ScoreRP", p);
			PlayerPrefs.SetInt ("ScoreActualRP", p);
			PlayerPrefs.SetInt ("NivelActualRP", nivelActual);
			PlayerPrefs.SetInt ("EstrellasRP", estrellas);
			if (estrellas >= 3 && nivel == nivelActual) {
				nivel = nivel + 1;
			}
			PlayerPrefs.SetInt ("NivelRP", nivel);
			string mensaje = "";
			if (estrellas == 5) {
				mensaje = "Eres Excelente!";
			} else if (estrellas == 4) {
				mensaje = "Muy Bien!";
			} else if (estrellas == 3) {
				mensaje = "Felicidades!";
			} else if (estrellas == 2) {
				mensaje = "Casi lo logras!";
			} else if (estrellas == 1) {
				mensaje = "Sigue intentandolo!";
			} else if (estrellas == 0) {
				mensaje = "Debes practicar!";
			}
			PanelFinish.transform.GetChild (0).GetComponent<Text> ().text = mensaje;
			Stars.GetComponent<RectTransform> ().localScale = new Vector3 ((float)((float)estrellas / 10f), 0.5f, 1f);
			float w = (float)(((float)estrellas / 10f) * 2f);
			Stars.GetComponent<RawImage> ().uvRect = new Rect (0f, 0f, w, 1f);
			PlayerPrefs.SetString ("Save", "True");
			PanelFinish.SetActive (true);
			PanelFinish.transform.SetAsLastSibling ();
		}
	}

	public void Continuar(){
		Time.timeScale = 1f;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("ResolverProblemasMenu");	
	}
}
