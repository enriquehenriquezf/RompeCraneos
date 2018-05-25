using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerRP : MonoBehaviour {
	public GameObject fosforo;
	public GameObject PanelFinish;
	public GameObject Stars;
	public GameObject Spawner;
	GameObject[] go;
	float time = 0f;
	float delta = 0f;
	float finishtime = 0f;
	public float finishlvl = 60f;
	public int nivel = 0;
	public int nivelActual = 0;
	int estrellas = 0;
	bool finished = false;
	public int CantPalitos;
	public string palitos;
	// Use this for initialization
	void Start () {
		finishlvl = PlayerPrefs.GetFloat("finishlvl");
		nivelActual = PlayerPrefs.GetInt ("nivel");
		nivel = PlayerPrefs.GetInt ("nivelMax");
		CantPalitos = PlayerPrefs.GetInt ("Palitos");
		palitos = PlayerPrefs.GetString ("Palito");
		Time.timeScale = 1f;
		//Camera.main.GetComponent<LivingEntityAM> ().SetTime ((int)finishlvl);
		string[] s = palitos.Split(',');
		go = new GameObject[s.Length];
		for (int i = 0; i < s.Length; i++) {
			go[i] = (GameObject)Instantiate(fosforo,Spawner.transform);
			go[i].GetComponent<RectTransform>().localPosition = Spawner.transform.GetChild (int.Parse(s[i])).GetComponent<RectTransform>().localPosition;
			go[i].GetComponent<RectTransform>().localRotation = Spawner.transform.GetChild (int.Parse(s[i])).GetComponent<RectTransform>().localRotation;
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
				//Camera.main.GetComponent<LivingEntityAM> ().SetTime ((int)(finishlvl - finishtime));
			}
		}
		if (finishtime >= finishlvl && Time.timeScale == 1f && !finished) {
			Time.timeScale = 0f;
			//int p = Camera.main.GetComponent<LivingEntityAM> ().GetPuntos ();
			//float stars = (float)(((float)p / (float)cantCorrectas) / 2f) * 5f;
			//estrellas = Mathf.FloorToInt(stars);
			//if (p < 0) {estrellas = 0;}
			//PlayerPrefs.SetInt ("Score", p);
			//PlayerPrefs.SetInt ("ScoreActual", p);
			PlayerPrefs.SetInt ("NivelActual", nivelActual);
			PlayerPrefs.SetInt ("Estrellas", estrellas);
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

	public void Continuar(){
		Time.timeScale = 1f;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMentalMenu");	
	}
}
