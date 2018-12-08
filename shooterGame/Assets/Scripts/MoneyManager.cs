using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyManager : MonoBehaviour {

	public Text MoneyAnzeige;
	public static int coinAmount;

	void Start ()
	{
		MoneyAnzeige = GetComponent<Text>();
	}

	void Update () 
	{
		MoneyAnzeige.text = "$: " + coinAmount.ToString();
	}

	
}
