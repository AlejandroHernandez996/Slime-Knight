// Health_Bar_Script
// Shows what health you are with a bar

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar_Script : MonoBehaviour {
	
	public GameObject player;
	
	// Update is called once per frame
	void Update () {

		// Width is the percentage of health you are at
		float width = (float)player.GetComponent<Player_Manager> ().health/(float)player.GetComponent<Player_Manager> ().GetMaxHealth()*100.0f;
		RectTransform imageRect = GetComponent<Image> ().rectTransform.transform as RectTransform;
		// Set bar to width
		imageRect.sizeDelta = new Vector2 (width, imageRect.sizeDelta.y);

	}
}
