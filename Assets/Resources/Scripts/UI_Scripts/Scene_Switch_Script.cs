using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Switch_Script : MonoBehaviour {

	public string scene;
	void Start(){

		GetComponent<Button> ().onClick.AddListener (SwitchScene);

	}
	public void SwitchScene(){

		SceneManager.LoadScene (scene);

	}
}
