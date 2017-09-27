// Object Manager
// Handles data of an object
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Manager : MonoBehaviour {

	public int level, health;

	public void SetLevel(int l){
			level += l;
	}
	public int GetLevel(){

		return level;

	}
	public void SetHealth(int h){
		if (health +h< 0)
			health = 0;
		else
			health += h;
		
	}
	public int GetHealth(){

		return health;

	}
}
