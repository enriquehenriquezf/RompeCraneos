using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerAM : MonoBehaviour {
	private string[,] names = new string[,]{{"había","true"},{"abia","false"},{"hombre","true"},{"barco","true"},{"varco","false"},{"vacaciones","true"},{"vacasiones","false"},{"día","true"},{"dibujo","true"},{"hasta","true"},{"invierno","true"},{"inbierno","false"},{"verano","true"},{"berano","false"},{"jefe","true"},{"canguro","true"},{"máquina","true"},{"marrón","true"},{"árbol","true"},{"arvol","false"},{"abeja","true"},{"aveja","false"},{"bosque","true"},{"cigüeña","true"},{"selva","true"},{"selba","false"},{"oveja","true"},{"obeja","false"},{"ciervo","true"},{"cierbo","false"},{"gitana","true"},{"jitana","false"},{"guitarra","true"},{"queso","true"},{"zanahoria","true"},{"huevo","true"},{"hueso","true"},{"íbamos","true"},{"ivamos","false"},{"boca","true"},{"extranjero","true"},{"hijo","true"},{"vecina","true"},{"habitación","true"},{"lenguaje","true"},{"historia","true"},{"avión","true"},{"ambulancia","true"},{"bicicleta","true"},{"balón","true"},{"juego","true"},{"columpio","true"},{"navidad","true"},{"agujero","true"},{"feliz","true"},{"gobierno","true"},{"govierno","false"},{"hecho","true"},{"hacia","true"},{"todavía","true"},{"todabia","false"},{"cabeza","true"}};
	private string[,] names2 = new string[,]{{"beneficencia","true"},{"coger","true"},{"adversión","false"},{"beneficiencia","false"},{"consanguinidad","true"},{"conciencia","true"},{"contrición","true"},{"convalecencia","true"},{"cojer","false"},{"consanguineidad","false"},{"consciencia","false"},{"contricción","false"},{"constipado","true"},{"decisión","true"},{"convalescencia","false"},{"costipado","false"},{"desición","false"},{"diglosia","true"},{"digresión","true"},{"dislexia","true"},{"excéntrico","true"},{"disglosia","false"},{"disgresión","false"},{"dixlesia","false"},{"expectativa","true"},{"explanada","true"},{"escéntrico","false"},{"espectativa","false"},{"esplanada","false"},{"exalar","false"},{"exhalar","true"},{"exhausto","true"},{"escéptico","true"},{"exorbitante","true"},{"exausto","false"},{"excéptico","false"},{"exuberante","true"},{"exhortar","true"},{"extrínseco","true"},{"exhumar","true"},{"fidedigno","true"},{"garaje","true"},{"hemiplejía","true"},{"exhorbitante","false"},{"exhuberante","false"},{"exortar","false"},{"extrínsico","false"},{"idiosincrasia","true"},{"inescrutable","true"},{"infligido","true"},{"injerencia","true"},{"jerigonza","true"},{"exumar","false"},{"fideligno","false"},{"intrínseco","true"},{"misógino","true"},{"garage","false"},{"hemiplegía","false"},{"idiosincracia","false"},{"inexcrutable","false"},{"inflingido","false"},{"móvil","true"},{"prevaricación","true"},{"prever","true"},{"ingerencia","false"},{"intrínsico","false"},{"misógeno","false"},{"móbil","false"},{"surrealista","true"},{"prevadicación","false"},{"preveer","false"},{"subrealista","false"},{"sujeción","true"},{"trasplantar","true"},{"sujección","false"},{"jeringoza","false"},{"transplantar","false"},{"trastornado","true"},{"transtornado","false"},{"urgar","false"},{"vanal","false"},{"hurgar","true"},{"banal","true"}};
	private string[,] ecuaciones = new string[,]{{"3+3=6","true"},{"2+2=3","false"},{"7+2=9","true"},{"9+9=16","false"},{"3+7=10","true"},{"8+7=25","false"},{"3+15=18","true"},{"14+8=22","true"},{"5+56=65","false"},{"92+2=94","true"},{"15+6=21","true"},{"15+13=23","false"},{"9-6=8","false"},{"10-2=8","true"},{"7-3=8","false"},{"8-5=3","true"},{"9-7=3","false"},{"5-4=1","true"},{"8-3=5","true"},{"5-5=0","true"},{"8-2=7","false"},{"7-5=2","true"},{"8-4=4","true"},{"9-3=8","false"},{"8x9=72","true"},{"7x2=15","false"},{"2x9=18","true"},{"6x4=26","false"},{"4x9=36","true"},{"5x4=21","false"},{"3x10=30","true"},{"4x8=32","true"},{"6x9=55","false"},{"8x7=56","true"},{"6x8=48","true"},{"3x8=26","false"}};
	private string[,] ecuaciones2 = new string[,]{{"70+58=128","true"},{"16+41=59","false"},{"26+17=43","true"},{"5+99=105","false"},{"95+97=192","true"},{"75+38=115","false"},{"47+81=128","true"},{"54+85=139","true"},{"57+65=124","false"},{"39+44=83","true"},{"33+84=117","true"},{"45+77=126","false"},{"48-35=11","false"},{"62-24=38","true"},{"96-53=42","false"},{"84-28=56","true"},{"39-15=23","false"},{"40-14=26","true"},{"87-76=11","true"},{"86-10=76","true"},{"95-38=56","false"},{"90-81=9","true"},{"54-21=33","true"},{"69-46=28","false"},{"7x6=42","true"},{"3x9=26","false"},{"6x6=36","true"},{"9x3=24","false"},{"11x12=132","true"},{"7x9=66","false"},{"25÷5=5","true"},{"10÷2=5","true"},{"15÷5=5","false"},{"40÷4=10","true"},{"12÷6=2","true"},{"63÷7=7","false"}};
	private string[,] ecuaciones3 = new string[,]{{"878+929=1807 ","true"},{"101+714=824","false"},{"222+497=719","true"},{"225+21=244","false"},{"265+916=1181","true"},{"138+488=616","false"},{"641+400=1041","true"},{"447+502=949","true"},{"808-177=633","false"},{"841-331=510","true"},{"421-239=182","true"},{"591-461=145","false"},{"873-517=366","false"},{"478-146=332","true"},{"343-257=76","false"},{"970-834=136","true"},{"357-348=14","false"},{"956-763=193","true"},{"120*3=360","true"},{"45*5=225","true"},{"70*4=270","false"},{"36*15=540","true"},{"21*10=210","true"},{"40*20=810","false"},{"30÷6=5","true"},{"42÷6=8","false"},{"64÷8=8","true"},{"42÷7=5","false"},{"20÷5=4","true"},{"63÷7=8","false"},{"49÷7=9","false"},{"32÷8=4","true"},{"14÷2=7","true"},{"27÷9=4","false"},{"28÷4=7","true"},{"40÷5=8","true"}};
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
	public int dificultad = 0;
	public int pals = 0;
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
		dificultad = PlayerPrefs.GetInt ("dificultad");
		pals = PlayerPrefs.GetInt ("palabras");
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
			bool verdadero = false;
			string nombre = "";
			if (dificultad == 0) {
				int i = Random.Range (0, ecuaciones.GetLength (0));
				nombre = ecuaciones [i, 0];
				bool.TryParse (ecuaciones [i, 1], out verdadero);
			}
			else if (dificultad == 1) {
				int r = Random.Range (0, 2);
				if (r == 0) {
					int i = Random.Range (0, ecuaciones.GetLength (0));
					nombre = ecuaciones [i, 0];
					bool.TryParse (ecuaciones [i, 1], out verdadero);
				} else {
					int i = Random.Range (0, ecuaciones2.GetLength (0));
					nombre = ecuaciones2 [i, 0];
					bool.TryParse (ecuaciones2 [i, 1], out verdadero);
					
				}
			}
			else if (dificultad == 2) {
				int r = Random.Range (0, 3);
				if (r == 0) {
					int i = Random.Range (0, ecuaciones.GetLength (0));
					nombre = ecuaciones [i, 0];
					bool.TryParse (ecuaciones [i, 1], out verdadero);
				} else if(r == 1){
					int i = Random.Range (0, ecuaciones2.GetLength (0));
					nombre = ecuaciones2 [i, 0];
					bool.TryParse (ecuaciones2 [i, 1], out verdadero);

				} else if(r == 2){
					int i = Random.Range (0, ecuaciones3.GetLength (0));
					nombre = ecuaciones3 [i, 0];
					bool.TryParse (ecuaciones3 [i, 1], out verdadero);

				}
			}
			else if (dificultad == 3) {
				int r = Random.Range (0, 2);
				if (r == 0) {
					int i = Random.Range (0, ecuaciones3.GetLength (0));
					nombre = ecuaciones3 [i, 0];
					bool.TryParse (ecuaciones3 [i, 1], out verdadero);
				} else {
					int i = Random.Range (0, ecuaciones2.GetLength (0));
					nombre = ecuaciones2 [i, 0];
					bool.TryParse (ecuaciones2 [i, 1], out verdadero);

				}
			}
			else if (dificultad == 4) {
				int i = Random.Range (0, ecuaciones3.GetLength (0));
				nombre = ecuaciones3 [i, 0];
				bool.TryParse (ecuaciones3 [i, 1], out verdadero);
			}
			if (pals != 0) {
				int r = Random.Range (0,2);
				if (r == 0) {
					if (pals == 1) {
						int i = Random.Range (0, names.GetLength (0));
						nombre = names [i, 0];
						bool.TryParse (names [i, 1], out verdadero);
					} else if (pals == 2) {
						int i = Random.Range (0, names2.GetLength (0));
						nombre = names2 [i, 0];
						bool.TryParse (names2 [i, 1], out verdadero);
					}
				}
			}
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
