using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunkteManager : MonoBehaviour {

	public Text punkteAnzeige;

	public float punkteZaehler;
	public float punkteProSekunde;

	public bool punkteIncreasing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		punkteAnzeige.text = "Punkte: " + punkteZaehler;
	}
}
