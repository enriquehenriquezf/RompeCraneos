using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerAM : MonoBehaviour {
	private string[,] names = new string[,]{{"vibir","false"},{"vivir","true"}};
	private string[,] ecuaciones = new string[,]{{"3+2=5","true"},{"7*8=57","false"},{"6*8=48","true"},{"6*9=53","false"}};
	public GameObject boton;
	public GameObject PanelFinish;
	public GameObject Stars;
	GameObject go;
	float time = 0f;
	float delta = 0f;
	public float spawn = 1f;
	public float deadtime = 5f;
	float finishtime = 0f;
	public float finishlvl = 60f;
	public int vel = 4;
	public int nivel = 0;
	public int nivelActual = 0;
	int cantCorrectas = 0;
	int estrellas = 0;
	bool finished = false;
	// Use this for initialization
	void Start () {
		vel = PlayerPrefs.GetInt ("vel");
		spawn = PlayerPrefs.GetFloat("spawn");
		finishlvl = PlayerPrefs.GetFloat("finishlvl");
		deadtime = PlayerPrefs.GetFloat("deadtime");
		nivelActual = PlayerPrefs.GetInt ("nivel");
		nivel = PlayerPrefs.GetInt ("nivelMax");
		Time.timeScale = 1f;
		Camera.main.GetComponent<LivingEntityAM> ().SetTime ((int)finishlvl);
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
				Camera.main.GetComponent<LivingEntityAM> ().SetTime ((int)(finishlvl - finishtime));
			}
		}
		if (time == spawn  && finishtime < finishlvl) {
			float x = Random.Range (-350,350);
			int i = Random.Range (0,ecuaciones.GetLength(0));
			string nombre = ecuaciones [i, 0];
			bool verdadero = false;
			bool.TryParse(ecuaciones [i, 1],out verdadero);
			//Transform t = this.transform;
			//t.transform.position = new Vector3 (x, 410f, 0f);
			go = (GameObject)Instantiate(boton,this.transform);
			go.GetComponent<RectTransform>().localPosition = new Vector3 (x, 410f, 0f);
			go.GetComponentInChildren<Text> ().text = nombre;
			go.GetComponent<AgilidadMental> ().SetName (nombre);
			go.GetComponent<AgilidadMental> ().SetCorrecta (verdadero);
			if (verdadero) {
				cantCorrectas++;
			}
			go.GetComponent<AgilidadMental> ().SetVelocidad (vel);
			go.GetComponent<AgilidadMental> ().SetDeadTime (deadtime);
			time = 0f;
		}
		if (finishtime >= finishlvl && Time.timeScale == 1f && !finished) {
			Time.timeScale = 0f;
			//TODO:	Arreglar cuadro con puntaje y estrellas ganadas
			int p = Camera.main.GetComponent<LivingEntityAM> ().GetPuntos ();
			float stars = (float)(((float)p / (float)cantCorrectas) / 2f) * 5f;
			estrellas = Mathf.FloorToInt(stars);
			if (p < 0) {estrellas = 0;}
			PlayerPrefs.SetInt ("Score", p);
			PlayerPrefs.SetInt ("ScoreActual", p);
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
