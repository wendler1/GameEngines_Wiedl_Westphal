using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spieler : MonoBehaviour {

	float eingabeFaktor = 10;
	public GameObject[] geschoss = new GameObject[3];
	public GefahrGewinn gefahrGewinnKlasse;
	public GrumpyGefahr grumpyGefahrKlasse;
	public MoneyPickUp moneyPickUpKlassse;
	public MoneyEnemyPickUp moneyEnemyPickUpKlasse;
	int energie = 3;
	public GameObject balkenWert;
	public GameObject[] gefahr = new GameObject[3];
	public GameObject gewinn;
	public GameObject grumpyGefahr;
	public GameObject coin;
	public GameObject coinShine;
	public float zeitStart;
	bool spielGestartet = true;
	public Text zeitAnzeige;
	public Text infoAnzeige;
	public DeathMenu deathMenuScreen;
	public WinMenu winMenuScreen;
	public AudioClip kollisionGruenAudio;
	public AudioClip kollisionRotAudio;
	public AudioClip geschossAudio;
	public AudioClip gewonnenAudio;
	public AudioClip verlorenAudio;
	public ScoreManager theScoreManager;
	public GameObject buttonPause;

	


	// timeSinceLevelLoad das nach jedem neuen sceneload der timer sich auf null zurück setzt
	public void start ()
	{
		zeitStart = Time.timeSinceLevelLoad;

		theScoreManager = FindObjectOfType<ScoreManager>(); // zugriff auf die ScoreManager Klasse
	}


	// die Betaetigung der Tasten 'oben' und 'unten' fuehrt zu einer Bewegung des Spielers in Y-Richtung. -4.25f und 4.25f
	// ist die Bereichabgrenzung des Spielers
	public void Update()
	{
		float yEingabe = Input.GetAxis("Vertical");
		float yNeu = transform.position.y + yEingabe * eingabeFaktor * Time.deltaTime;
		if (yNeu > 4.25f)       yNeu = 4.25f;
		else if (yNeu < -4.25f) yNeu = -4.25f;
		transform.position = new Vector3(transform.position.x, yNeu, 0);


		// die statische Methode GetButtonDown() der Klasse Input liefert ob die virtuelle 'fire' taste gedrueckt ist
		if (Input.GetButtonDown ("Fire1"))
		{
			Shoot();
		}
		if(spielGestartet)
			zeitAnzeige.text = string.Format("Zeit: {0,6:0.0} sec.", Time.timeSinceLevelLoad - zeitStart);		
	}


	// getroffenes Objekt wird als neues Objekt an eine zufaellige Startposition gesetzt und die Geschwindigkeit erhoeht
	// sich um 1%
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Gefahr")
		{
			coll.gameObject.transform.position = new Vector3 (Random.Range(14.5f, 15.0f), Random.Range(-4.25f, 4.25f), 0);
			gefahrGewinnKlasse.xAenderungBasis *= 1.01f;
			AudioSource.PlayClipAtPoint(kollisionRotAudio, transform.position);
			EnergieAnzeige (-1);
		}
		if (coll.gameObject.tag == "Gefahr1")
		{
			coll.gameObject.transform.position = new Vector3 (Random.Range(17.5f, 11.0f), Random.Range(-4.25f, 4.25f), 0);
			gefahrGewinnKlasse.xAenderungBasis *= 1.01f;
			AudioSource.PlayClipAtPoint(kollisionRotAudio, transform.position);
			EnergieAnzeige (-1);
		}
		if (coll.gameObject.tag == "Gefahr2")
		{
			coll.gameObject.transform.position = new Vector3 (Random.Range(24f, 28.0f), Random.Range(-4.25f, 4.25f), 0);
			gefahrGewinnKlasse.xAenderungBasis *= 1.01f;
			AudioSource.PlayClipAtPoint(kollisionRotAudio, transform.position);
			EnergieAnzeige (-1);
		}
		if (coll.gameObject.tag == "Gefahr3")
		{
			coll.gameObject.transform.position = new Vector3 (Random.Range(14.5f, 15.0f), Random.Range(-4.25f, 4.25f), 0);
			gefahrGewinnKlasse.xAenderungBasis *= 1.01f;
			AudioSource.PlayClipAtPoint(kollisionRotAudio, transform.position);
			EnergieAnzeige (-1);
		}
		else if (coll.gameObject.tag == "Gewinn")
		{
			coll.gameObject.transform.position = new Vector3 (Random.Range(10.5f, 13.0f), Random.Range(-4.25f, 4.25f), 0);
			gefahrGewinnKlasse.xAenderungBasis *= 1.01f;
			AudioSource.PlayClipAtPoint(kollisionGruenAudio, transform.position);
			EnergieAnzeige (1);
		}
		if (coll.gameObject.tag == "GrumpyGefahr")
		{
			coll.gameObject.transform.position = new Vector3 (Random.Range(59.5f, 69.0f), Random.Range(-4.25f, 4.25f), 0);
			grumpyGefahrKlasse.xAenderungBasis *= 1.01f;
			AudioSource.PlayClipAtPoint(kollisionRotAudio, transform.position);
			EnergieAnzeige (-1);
		}
		if (coll.gameObject.tag == "Coin")
		{
			coll.gameObject.transform.position = new Vector3 (Random.Range(20.5f, 18.0f), Random.Range(-4.25f, 4.25f), 0);
			moneyPickUpKlassse.xAenderungBasis *= 1.01f;
			AudioSource.PlayClipAtPoint(kollisionGruenAudio, transform.position);
		}
		if (coll.gameObject.tag == "CoinShine")
		{
			coll.gameObject.transform.position = new Vector3 (Random.Range(9.5f, 19.0f), Random.Range(-4.25f, 4.25f), 0);
			moneyPickUpKlassse.xAenderungBasis *= 1.01f;
			AudioSource.PlayClipAtPoint(kollisionGruenAudio, transform.position);
		}

	}
	
	public void EnergieAnzeige(int wert)
	{
		energie += wert;
		balkenWert.transform.localScale = new Vector3 (energie / 2.0f, 0.8f, 0);
		if (energie > 40)
			EndeSpiel ("gewonnen", gewonnenAudio);
		else if (energie < 1)
			EndeSpiel ("verloren", verlorenAudio);
	}

	public void Shoot () 
	{
		// die statische Methode GetButtonDown() der Klasse Input liefert ob die virtuelle 'fire' taste gedrueckt ist
		for(int i=0; i<3; i++)
			if (!geschoss[i].activeSelf)
			{
				geschoss[i].transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, 0);
				geschoss[i].SetActive (true);
				AudioSource.PlayClipAtPoint(geschossAudio, transform.position);
				break;
			} 
	} 

	void EndeSpiel(string tx, AudioClip endeTon)
	{

		if (energie > 40)
		{
			spielGestartet = false;
			infoAnzeige.text = "Sie haben " + tx;
			AudioSource.PlayClipAtPoint(endeTon, transform.position);
			winMenuScreen.gameObject.SetActive(true);
		}
		else if (energie < 1)
		{
			spielGestartet = false;
			infoAnzeige.text = "Sie haben " + tx;
			AudioSource.PlayClipAtPoint(endeTon, transform.position);
			deathMenuScreen.gameObject.SetActive(true);
		}
		
		/* spielGestartet = false;
		infoAnzeige.text = "Sie haben " + tx;
		deathMenuScreen.gameObject.SetActive(true); */

	    for (int i = 0; i < 3; i++)
		{
			geschoss [i].SetActive (false);
			gefahr [i].SetActive (false);
		} 
		gewinn.SetActive (false);
		grumpyGefahr.SetActive(false);
		
		theScoreManager.scoreIncreasing = false;
		buttonPause.SetActive(false);
		coin.SetActive(false);
	
	}
 
}
