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

	public void AMMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AgilidadMentalMenu");
		PlayerPrefs.SetString ("Save","False");
		PlayerPrefs.SetString ("Load", "True");
	}
	public void RPMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("ResolverProblemasMenu");
		PlayerPrefs.SetString ("Save","False");
		PlayerPrefs.SetString ("Load", "True");
	}
}
