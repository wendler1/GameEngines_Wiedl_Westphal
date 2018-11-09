using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GefahrGewinn : MonoBehaviour {
  
	public Spieler spielerKlasse;

	public float xAenderungBasis;
	float xAenderung;

	// Gegner und Freunde erhalten eine individuelle Geschwindigkeit, die sich im Durchschnitt langsam steigert.
	void Start ()
	{
		xAenderungBasis = 2.5f * Time.deltaTime;
		xAenderung = 2.5f * Time.deltaTime;
	}
	
	// Aus dem Startwert fuer xAenderung ergibt sich die Geschwindigkeit der ersten 4 Objekte von rechts kommend,
	// hier folgt die Realisierung der Bewegung. Die x-Position aendert sich jeweils um die xAenderung
	void Update () 
		{
		transform.position = new Vector3 (transform.position.x - xAenderung, transform.position.y, 0);
		// Falls ein Objekt den sichtbaren Bereich nach links verlassen hat, erscheint es als ein neues, schnelleres 
		// Objekt von einer neuen Startposition 
		if (transform.position.x < -9.5f)
		{
			transform.position = new Vector3 (Random.Range(9.5f, 19.0f), Random.Range(-4.75f, 4.75f), 0);
			xAenderungBasis *= 1.01f;
			xAenderung = xAenderungBasis * Random.Range(0.7f, 1.3f);
			if (gameObject.tag == "Gefahr")
				spielerKlasse.EnergieAnzeige (-1);
		}
	}
}
