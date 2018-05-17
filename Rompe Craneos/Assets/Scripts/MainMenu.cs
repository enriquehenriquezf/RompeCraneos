using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AgilidadMentalMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMentalMenu");
	}
	public void ResolverProblemasMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("ResolverProblemasMenu");
	}
}
