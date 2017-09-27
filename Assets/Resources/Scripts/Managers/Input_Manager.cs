// Input Manager
// Handles input of player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour {
	private float dragDistance;
	private Vector3 firstPoint, lastPoint;
	void Start(){
		
		// Min drag is %15 of screen height
		dragDistance = Screen.height * 15 / 100;

	}
	// Checks if a swipe has occured then returns a value
	public int CheckSwipe(){

		if (Input.touchCount == 1) { // Could be swipe

			Touch touch = Input.GetTouch (0); // Get Touch

			if (touch.phase == TouchPhase.Began) {// Check first touch

				firstPoint = touch.position;// Sets firstTouch position
				lastPoint = touch.position;// Sets last position

			} else if (touch.phase == TouchPhase.Moved) {

				lastPoint = touch.position; // If touch moved set lastPoint to current position

			} else if (touch.phase == TouchPhase.Ended) {
				lastPoint = touch.position; // if it has ended set last point to position

				if (Mathf.Abs (lastPoint.y - firstPoint.y) > dragDistance) { // if more than the min dragDistance has happened it is a swipe


					if (lastPoint.y > firstPoint.y) { // if swipe up
						return 1;
					} else {
						return -1; // if swipe down
					}

				}
			} 



		}
		return 0;
	}
}
