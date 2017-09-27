using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Manager : MonoBehaviour {

    public GameObject player;
    public GameObject boss;
    // Update is called once per frame
    void Update()
    {

        if (player.GetComponent<Player_Manager>().health <= 0 || boss.GetComponent<Enemy_Manager>().health <= 0)
        {

            SceneManager.LoadScene("World_Map_Scene");

        }
    }
}
