using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geschoss : MonoBehaviour {

	public Spieler spielerKlasse;
	public GefahrGewinn	gefahrGewinnKlasse;
	public GrumpyGefahr grumpyGefahrKlasse;
	public GameObject explosionRot;
	public GameObject explosionGruen;
	public AudioClip explosionRotAudio;
	public AudioClip explosionGruenAudio;

	// hier wird ein Geschoss gleichzeitig nach rechts bewegt, hat es die Position 7.5 erreicht wird es deaktiviert und an die 
	// Ausgangsposition auserhalb des sichtbaren Bereichs zurueckgesetzt
	void Update () 
	{
		transform.position = new Vector3 (transform.position.x + 5 * Time.deltaTime, transform.position.y, 0);
		if (transform.position.x > 7.5f)
		{
			transform.position = new Vector3 (-9.5f, 0, 0);
			gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Gefahr") 
		{
			Instantiate(explosionRot, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(explosionRotAudio, transform.position);
			spielerKlasse.EnergieAnzeige (1);

			transform.position = new Vector3 (-9.5f, 0, 0); // erzeugt neues Geschoss
			gameObject.SetActive(false);
			coll.gameObject.transform.position = new Vector3 (Random.Range(9.5f, 19.0f), Random.Range(-4.7f, 4.75f), 0); // erzeugt neues von rechts kommendes Objekt
			gefahrGewinnKlasse.xAenderungBasis *= 1.01f; // erhoeht die Basis der zufaelligen Geschwindigkeitsaenderung um 1%
		}
		else if (coll.gameObject.tag == "Gewinn")
		{
			Instantiate(explosionGruen, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(explosionGruenAudio, transform.position);
			spielerKlasse.EnergieAnzeige (-1);

			transform.position = new Vector3 (-9.5f, 0, 0); // erzeugt neues Geschoss
			gameObject.SetActive(false);
			coll.gameObject.transform.position = new Vector3 (Random.Range(9.5f, 19.0f), Random.Range(-4.7f, 4.75f), 0); // erzeugt neues von rechts kommendes Objekt	
			gefahrGewinnKlasse.xAenderungBasis *= 1.01f; // erhoeht die Basis der zufaelligen Geschwindigkeitsaenderung um 1%
		}
		if (coll.gameObject.tag == "GrumpyGefahr") 
		{
			Instantiate(explosionRot, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(explosionRotAudio, transform.position);
			spielerKlasse.EnergieAnzeige (1);

			transform.position = new Vector3 (-9.5f, 0, 0); // erzeugt neues Geschoss
			gameObject.SetActive(false);
			coll.gameObject.transform.position = new Vector3 (Random.Range(59.5f, 69.0f), Random.Range(-4.7f, 4.75f), 0); // erzeugt neues von rechts kommendes Objekt
			grumpyGefahrKlasse.xAenderungBasis *= 1.01f; // erhoeht die Basis der zufaelligen Geschwindigkeitsaenderung um 1%
		}

	}

}
