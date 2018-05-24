using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IrEscena : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	public void CargarNiveles(string pEscena){
		SceneManager.LoadScene (pEscena);
	}
	public void CerrarJuego(){
		Application.Quit();
	}
}
