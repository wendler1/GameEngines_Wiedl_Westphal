using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geschossgegner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () 
	{
		transform.position = new Vector3 (transform.position.x + 5 * Time.deltaTime, transform.position.y, 0);
		if (transform.position.x > -7.5f)
		{
			transform.position = new Vector3 (9.5f, 0, 0);
			gameObject.SetActive(false);
		}
	}
}
