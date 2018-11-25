﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string starteScene0;

	public void playGame () {
		// Application.LoadLevel(starteScene0);
		SceneManager.LoadScene(starteScene0);
	}

	public void endGame () {
		Application.Quit();
	}
}
