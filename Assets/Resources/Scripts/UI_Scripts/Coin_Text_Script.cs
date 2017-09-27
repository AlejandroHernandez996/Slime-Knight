// Coin_Text_Script
// Sets UI Text for player coins
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Text_Script : MonoBehaviour {


	// Update is called once per frame
	void Update () {

		// Set UI text to number of coins
		GetComponent<Text> ().text = PlayerPrefs.GetInt("coins").ToString();
	}
}
