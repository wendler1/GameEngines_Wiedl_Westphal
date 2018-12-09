using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp: MonoBehaviour {

	public bool doublePoints;
	public float powerUpLength;
	public PowerUpManager thePowerUpManager;
	public float xAenderungBasis;
	float xAenderung;




	void Start () 
	{
		xAenderungBasis = 2.5f * Time.deltaTime;
		xAenderung = 2.5f * Time.deltaTime;	
	}
	

	void Update () 
	{
		transform.position = new Vector3 (transform.position.x - xAenderung, transform.position.y, 0);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			Debug.Log ("Hit");
			thePowerUpManager.ActivatePowerUp(doublePoints, powerUpLength);
		}
		gameObject.SetActive(false);
	}
}
