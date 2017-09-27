using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map_Manager_Script : MonoBehaviour {

	private int levelPick;
	private string[] worlds = { "Home_World", "Forest_World", "Glacier_World", "Castle_World" ,"Boss_World"};
	public Text text;
    public string levelName;
    public GameObject bossWorld;
	public void SetLevel(int l,string n){
		levelPick = l;
        levelName = n;
	}
	void Update(){
		text.text = levelName;
        if (PlayerPrefs.GetInt("lv") > 10)
        {
            bossWorld.gameObject.SetActive(true);
        }
	}
	public void LoadLevel(){

		SceneManager.LoadScene (worlds [levelPick]);

	}
}
