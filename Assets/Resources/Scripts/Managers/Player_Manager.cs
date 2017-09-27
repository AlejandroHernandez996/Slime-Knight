// Player Manager
// Handles player data
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : Object_Manager {

	private float xp, levelUpXp;
	private int coinAmount;
	private string[] weaponArray = { "Bronze_Sword", "Silver_Sword", "Gold_Sword" };
	private string[] armorArray = { "Bronze_Helmet", "Silver_Helmet", "Gold_Helmet" };
    public bool[] ownedWeapons;
    public bool[] ownedHelmets;
    public int currentWeapon;
    public int currentArmor;
	private GameObject weapon;
	private GameObject helmet;
	private int maxHealth;
    


	void Start(){

        currentWeapon = PlayerPrefs.GetInt("weapon");
		currentArmor = PlayerPrefs.GetInt("helmet");
		coinAmount = PlayerPrefs.GetInt ("coins");
		xp = PlayerPrefs.GetFloat ("xp");
		levelUpXp = PlayerPrefs.GetFloat ("lvXp");
		level = PlayerPrefs.GetInt ("lv");
        ownedHelmets = JsonUtility.FromJson<First_Load_Script.BoolArray>(PlayerPrefs.GetString("ownedHelmets")).arr;
        ownedWeapons = JsonUtility.FromJson<First_Load_Script.BoolArray>(PlayerPrefs.GetString("ownedWeapons")).arr;



        SwitchWeapon();
        SwitchHelmet();

	
		// Player health is their level + helmet level
		health = level+helmet.GetComponent<Helmet_Script> ().level;
		maxHealth = health;

	}

	void Update(){
		
		PlayerPrefs.SetInt ("coins",coinAmount);
		PlayerPrefs.SetFloat ("xp",xp);
		PlayerPrefs.SetFloat ("lvXp",levelUpXp);
		PlayerPrefs.SetInt ("lv",level);
        


        // Level up
        if (xp >= levelUpXp) {
			//Level up
			level++;
			PlayerPrefs.SetInt ("lv", level);
			// Replenish health
			health = level+helmet.GetComponent<Helmet_Script> ().level;
			maxHealth = health;
			// Reset xp
			xp -= levelUpXp;
			PlayerPrefs.SetFloat ("xp", xp);

            // Increase levelUp XP
            levelUpXp += levelUpXp / 2;
			PlayerPrefs.SetFloat ("lvXp", levelUpXp);

		}
	}
	// Adda coin to player
	public void AddCoin(int c){
        coinAmount += c;
		PlayerPrefs.SetInt ("coins", coinAmount);
	}
	// Returns Coins
	public int GetCoins(){
		return coinAmount;
	}
	public void SetXp(float x){

		xp += x;
	}
	public int GetMaxHealth(){
		return maxHealth;
	}
    public void SwitchWeapon()
    {
        weapon = Resources.Load("Prefabs/Weapons/" + weaponArray[currentWeapon]) as GameObject;

        Instantiate(weapon, new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y), Quaternion.identity);

        

    }
    public void SwitchHelmet()
    {
        helmet = Resources.Load("Prefabs/Armor/" + armorArray[currentArmor]) as GameObject;

        var myHelmet = Instantiate(helmet, new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + .125f), Quaternion.identity) as GameObject;
        myHelmet.transform.parent = gameObject.transform;
        myHelmet.transform.position += new Vector3(0, 0, -2);
    }
}
