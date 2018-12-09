using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

	private bool doublePoints;
	private bool powerUpActive;
	private float powerUpLengthCounter;
	public ScoreManager theScoreManager;
	private float normalPointsPerSecond;
	public GameObject floatingTextPrefab; 

	
	void Start () 
	{
		floatingTextPrefab.SetActive(false);
	}
	
	
	void Update () 
	{
		if (powerUpActive)
		{
			powerUpLengthCounter -= Time.deltaTime;

			if (doublePoints)
			{
				floatingTextPrefab.SetActive(true);
				theScoreManager.pointsPerSecond = normalPointsPerSecond * 3;
			}
			
			if (powerUpLengthCounter <= 0) 
			{
				theScoreManager.pointsPerSecond = normalPointsPerSecond;
				powerUpActive = false;
				floatingTextPrefab.SetActive(false);
			}
		}
		
	}

	public void ActivatePowerUp (bool points, float time)
	{
		doublePoints = points;
		powerUpLengthCounter = time;

		normalPointsPerSecond = theScoreManager.pointsPerSecond;

		powerUpActive = true;
	}
}
