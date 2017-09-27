// Stats_Script
// Sets UI level text
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats_Script : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

		// UI Text to indicate current level
		GetComponent<Text> ().text = string.Format ("Level: {0}", PlayerPrefs.GetInt("lv"));
	}
}
