﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;
	public string starteScene0;
	public GameObject MenuPause;
	public GameObject[] gefahr = new GameObject[3];
	public GameObject gewinn;
	
	

	public void PauseGame () 
	{
		Time.timeScale = 0f;
		MenuPause.SetActive(true);
		for (int i = 0; i < 3; i++)
		{
			gefahr[i].SetActive(false);
		}

		gewinn.SetActive(false);
		
	}

	public void ResumeGame () 
	{
		Time.timeScale = 1f;
		MenuPause.SetActive(false);
		for (int i = 0; i < 3; i++)
		{
			gefahr[i].SetActive(true);
		}
		gewinn.SetActive(true);
		
	}

	public void neustartSpiel () 
	{
		Time.timeScale = 1f;
		MenuPause.SetActive(false);
		// Application.LoadLevel(starteScene0);
		SceneManager.LoadScene(starteScene0);
	}
	
	public void returnHome () 
	{
		Time.timeScale = 1f;
		// Application.LoadLevel(mainMenuLevel);
		SceneManager.LoadScene(mainMenuLevel);
	}
}