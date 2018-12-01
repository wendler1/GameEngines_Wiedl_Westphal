﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highscoreText;

	public float scoreCount;
	public float highscoreCount;

	public float pointsPerSecond;
	public bool scoreIncreasing;
	
	void Start () 
	{
		if (PlayerPrefs.HasKey("Highscore"))
		{
			highscoreCount = PlayerPrefs.GetFloat("Highscore");
		}
	}
	
	
	void Update () 
	{
		if (scoreIncreasing)
		{
			scoreCount += pointsPerSecond * Time.deltaTime;
		}
	
		if (scoreCount > highscoreCount)
		{
			highscoreCount = scoreCount;
			PlayerPrefs.SetFloat("Highscore", highscoreCount);
		}
		scoreText.text = "Score: " + Mathf.Round(scoreCount);
		highscoreText.text = "Highscore: " + Mathf.Round(highscoreCount);
	} 
}
