using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyEnemyPickUp : MonoBehaviour {

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
		if (transform.position.x < -9.5f)
		{
			transform.position = new Vector3 (Random.Range(9.5f, 19.0f), Random.Range(-4.75f, 4.75f), 0);
			xAenderungBasis *= 1.01f;
			xAenderung = xAenderungBasis * Random.Range(0.7f, 1.3f);
		}
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			MoneyManager.coinAmount += 25;    // ladet das Script MoneyManager
			Destroy(gameObject);
		}
	}

}
