using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager_Script : MonoBehaviour {

	public GameObject player;
    public GameObject room;
	// Update is called once per frame
	void Update () {

		if (player.GetComponent<Player_Manager> ().health <= 0) {

			SceneManager.LoadScene ("World_Map_Scene");

		}
        if(player.transform.position.x > room.GetComponent<Room_Generator>().tileLength - room.GetComponent<Room_Generator>().endLength / 2){
            SceneManager.LoadScene("World_Map_Scene");
        }
	}
}
