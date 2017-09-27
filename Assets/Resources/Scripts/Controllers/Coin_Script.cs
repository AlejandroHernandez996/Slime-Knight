// Coin Script
// Moves and destroys coin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Coin moves to the left
		GetComponent<Transform> ().position += Vector3.left * .05f;

		// When it reaches the end it destroys itself
		if (GetComponent<Transform> ().position.x < -8) {

			Destroy (gameObject);
		}
	}
}
