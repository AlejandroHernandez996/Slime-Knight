using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats_Button_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (Output);
	}
	
	// Update is called once per frame
	void Update () {
		

	}
	void Output(){
		Debug.Log (string.Format ("Level: {0} XP: {1} XPCAP: {2} Coins: {3} Weapon: {4} Helmet: {5}",
			PlayerPrefs.GetFloat ("lv", 1),
			PlayerPrefs.GetFloat ("xp", 0),
			PlayerPrefs.GetFloat ("lvXp", 100),
			PlayerPrefs.GetInt ("coins", 0),
			PlayerPrefs.GetInt ("weapon", 0),
			PlayerPrefs.GetInt ("helmet", 0)));
			

	}
	
}
