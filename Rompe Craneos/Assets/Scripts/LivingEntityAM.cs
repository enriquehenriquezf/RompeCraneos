using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingEntityAM : MonoBehaviour {
	public Text score;
	public Text time;
	private int puntos = 0;
	private int tiempo = 60;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "puntos: " + puntos;
		time.text = "Tiempo: " + tiempo;
	}

	public void AddPuntos(int p)
	{
		puntos = puntos + p;
	}

	public void SetTime(int t)
	{
		tiempo = t;
	}

	public int GetPuntos(){
		return puntos;
	}
}