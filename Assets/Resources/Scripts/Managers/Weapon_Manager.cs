// Weapon Manager
// Manages Weapon Stats
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Manager : Object_Manager {
    public int cost;
    public string nameDesc;
    public int index;
	void Start(){
		// Set weapon health to its level
		health = level;
	}

}
