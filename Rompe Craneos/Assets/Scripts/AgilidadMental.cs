using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgilidadMental : MonoBehaviour {
	private string nombre = "";
	private bool correcta = false;
	float time = 0f;
	float delta = 0f;
	float vel = 4f;
	bool verificando = false;
	float deadtime = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 1f) {
			this.transform.Translate (0f, -vel, 0f);
			delta += Time.deltaTime;
			if (delta > 1f) {
				time += 1;
				delta = 0;
			}
			if (time == deadtime && !verificando) {
				if (correcta) {
					Camera.main.GetComponent<LivingEntityAM> ().AddPuntos (-1);
				}
				Destroy (this.gameObject);
			}
		}
	}

	public void SetName(string n){
		nombre = n;
	}
	public void SetCorrecta(bool c){
		correcta = c;
	}
	public void SetVelocidad(int v){
		vel = v;
	}
	public bool GetCorrecta(){
		return correcta;
	}

	public void Verificar(){
		verificando = true;
		if (GetCorrecta ()) {
			Camera.main.GetComponent<LivingEntityAM>().AddPuntos(2);
		} else {
			Camera.main.GetComponent<LivingEntityAM>().AddPuntos(-1);
		}
		Destroy (this.gameObject);
	}
}
