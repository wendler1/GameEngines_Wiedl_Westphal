using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string starteScene0;

	public void playGame () {
		Application.LoadLevel(starteScene0);
	}

	public void endGame () {
		Application.Quit();
	}
}
