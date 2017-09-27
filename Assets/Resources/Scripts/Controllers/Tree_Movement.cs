// Tree Movement
// Moves tree
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Movement : MonoBehaviour {


	public float moveSpeed;

	// Update is called once per frame
	void Update () {
		
		GetComponent<Transform> ().position += Vector3.left * moveSpeed;

		if (GetComponent<Transform> ().position.x < -8) {

			Destroy (gameObject);
		}
	}
}
