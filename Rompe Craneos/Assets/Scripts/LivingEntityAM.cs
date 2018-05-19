using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingEntityAM : MonoBehaviour {
	public Text score;
	private int puntos = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "puntos = " + puntos;
	}

	public void AddPuntos(int p)
	{
		puntos = puntos + p;
	}
}
