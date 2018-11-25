using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {

	public string mainMenuLevel;
	public string starteScene0;

	public void neustartSpiel () 
	{
		// Application.LoadLevel(starteScene0);
		SceneManager.LoadScene(starteScene0);
	}
	
	public void returnHome () 
	{
		// Application.LoadLevel(mainMenuLevel);
		SceneManager.LoadScene(mainMenuLevel);
	}
}

