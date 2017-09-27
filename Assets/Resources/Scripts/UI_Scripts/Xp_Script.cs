// Xp_Script
// Sets the xp bar width to xp to levelUpxP ratio
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Xp_Script : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		// Set width to percentage of Xp until level up
		float width = PlayerPrefs.GetFloat("xp")/PlayerPrefs.GetFloat("lvXp")*100;

		RectTransform imageRect = GetComponent<Image> ().rectTransform.transform as RectTransform;

		//Set Image with new width
		imageRect.sizeDelta = new Vector2 (width, imageRect.sizeDelta.y);

	}
}
