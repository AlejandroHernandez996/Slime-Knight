using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World_Load_Script : MonoBehaviour {

	public int currentLevel;
	public GameObject mapManager;
    public string nameD;

	void OnMouseDown(){

		mapManager.GetComponent<Map_Manager_Script> ().SetLevel (currentLevel,nameD);
	}
}
