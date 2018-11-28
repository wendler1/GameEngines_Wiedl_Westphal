using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveScript : MonoBehaviour {

	float directionX;
	public float moveSpeed = 15f;
	//Rigidbody2D rb;
	float eingabeFaktor = 10;
	
	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		 float directionX = CrossPlatformInputManager.GetAxis ("Vertical");
		 float yNeu = transform.position.y + directionX * eingabeFaktor * Time.deltaTime * moveSpeed;
		 if (yNeu > 4.25f)       yNeu = 4.25f;
		 else if (yNeu < -4.25f) yNeu = -4.25f;
		 transform.position = new Vector3(transform.position.x, yNeu, 0);

		 
		

		
	}


}
