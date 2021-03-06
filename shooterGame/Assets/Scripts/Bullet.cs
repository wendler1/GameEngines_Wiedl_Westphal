﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
	float moveSpeed = 7f;
	Rigidbody2D rb;

	public Spieler target;
	Vector2 moveDirection;
	public AudioClip kollisionRotAudio;

	
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindObjectOfType<Spieler>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		Destroy(gameObject, 3f);
		if (transform.position.x > 8f) {
			Destroy(gameObject);
		}


		
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.name.Equals ("Spieler"))
		{
			Debug.Log ("Hit");
			Destroy (gameObject);
			target.EnergieAnzeige(-1);
			AudioSource.PlayClipAtPoint(kollisionRotAudio, transform.position);
		}
	}

	
	
	void Update () 
	{
		
	}
}
