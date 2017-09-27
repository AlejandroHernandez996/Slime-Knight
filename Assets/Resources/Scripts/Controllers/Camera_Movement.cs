using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
	private bool found;
	void Start(){
		found = false;
	}
	void Update(){
		if (!found) {
			// Different from camera to player
			GetComponent<Transform>().position += new Vector3(3,2,0);
			offset = GetComponent<Transform>().position - player.transform.position;
			found = true;
		}
	}
	// LateUpdate is called after update
	void LateUpdate () {
		
		// Move camera to follow player
		if(found)
			GetComponent<Transform>().position = player.transform.position + offset;

	}
}
