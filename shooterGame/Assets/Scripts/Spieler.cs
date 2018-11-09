﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spieler : MonoBehaviour {

	float eingabeFaktor = 10;
	public GameObject[] geschoss = new GameObject[3];
	
	public GefahrGewinn gefahrGewinnKlasse;
	int energie = 10;
	public GameObject balkenWert;

	public GameObject[] gefahr = new GameObject[3];
	public GameObject gewinn;
	float zeitStart;
	bool spielGestartet = true;
	public Text zeitAnzeige;
	public Text infoAnzeige;

	void start ()
	{
		zeitStart = Time.time;
	}


	// die Betaetigung der Tasten 'oben' und 'unten' fuehrt zu einer Bewegung des Spielers in Y-Richtung. -4.75f und 4.75f
	// ist die Bereichabgrenzung des Spielers
	void Update()
	{
		float yEingabe = Input.GetAxis("Vertical");
		float yNeu = transform.position.y + yEingabe * eingabeFaktor * Time.deltaTime;
		if (yNeu > 4.75f)       yNeu = 4.75f;
		else if (yNeu < -4.75f) yNeu = -4.75f;
		transform.position = new Vector3(transform.position.x, yNeu, 0);

		// die statische Methode GetButtonDown() der Klasse Input liefert ob die virtuelle 'fire' taste gedrueckt ist
		if (Input.GetButtonDown ("Fire1"))
			for(int i=0; i<3; i++)
				if (!geschoss[i].activeSelf)
				{
					geschoss[i].transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, 0);
					geschoss[i].SetActive (true);
					break;
				}
		if(spielGestartet)
			zeitAnzeige.text = string.Format("Zeit: {0,6:0.0} sec.", Time.time - zeitStart);		
	}

	// getroffenes Objekt wird als neues Objekt an eine zufaellige Startposition gesetzt und die Geschwindigkeit erhoeht
	// sich um 1%
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Gefahr")
		{
			coll.gameObject.transform.position = new Vector3 (Random.Range(9.5f, 19.0f), Random.Range(-4.75f, 4.75f), 0);
			gefahrGewinnKlasse.xAenderungBasis *= 1.01f;
			EnergieAnzeige (-1);
		}
		else if (coll.gameObject.tag == "Gewinn")
		{
			coll.gameObject.transform.position = new Vector3 (Random.Range(9.5f, 19.0f), Random.Range(-4.75f, 4.75f), 0);
			gefahrGewinnKlasse.xAenderungBasis *= 1.01f;
			EnergieAnzeige (1);
		}
	}
	
	public void EnergieAnzeige(int wert)
	{
		energie += wert;
		balkenWert.transform.localScale = new Vector3 (energie / 2.0f, 0.8f, 0);
		if (energie > 40)
			EndeSpiel ("gewonnen");
		else if (energie < 1)
			EndeSpiel ("verloren");
	}

	void EndeSpiel(string tx)
	{
		spielGestartet = false;
		infoAnzeige.text = "Sie haben " + tx;

		for (int i = 0; i < 3; i++)
		{
			geschoss [i].SetActive (false);
			gefahr [i].SetActive (false);
		}
		gewinn.SetActive (false);
	}
}
