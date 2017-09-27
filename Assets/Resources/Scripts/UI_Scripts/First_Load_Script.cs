using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Load_Script : MonoBehaviour {
    int firstRun;
    // Use this for initialization
    [System.Serializable]
    public class BoolArray
    {
        public bool[] arr;

        public BoolArray(bool[] init)
        {
            this.arr = init;
        }
    }
    void Start () {
		firstRun = PlayerPrefs.GetInt ("firstRun");	

		if (firstRun !=1) {
            firstRun = 1;
            PlayerPrefs.SetInt("firstRun", firstRun);
            PlayerPrefs.SetInt ("weapon",0);
			PlayerPrefs.SetInt ("helmet",0);
			PlayerPrefs.SetInt ("coins",0);
			PlayerPrefs.SetFloat ("xp",0);
			PlayerPrefs.SetFloat ("lvXp",100);
			PlayerPrefs.SetInt ("lv",1);
            
            bool[] array = new bool[]{ true, false, false };

            BoolArray ownedWeapons = new BoolArray(array);
            BoolArray ownedHelmets = new BoolArray(array);

            PlayerPrefs.SetString("ownedWeapons", JsonUtility.ToJson(ownedWeapons));
            PlayerPrefs.SetString("ownedHelmets", JsonUtility.ToJson(ownedHelmets));
            Debug.Log(JsonUtility.ToJson(ownedWeapons));

		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
