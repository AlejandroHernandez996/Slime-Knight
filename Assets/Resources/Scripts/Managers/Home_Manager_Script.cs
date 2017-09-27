using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home_Manager_Script : MonoBehaviour {
    public Text nameD;
    public Text amount;
    public Image coin;
    public Button equip, buy;
    public GameObject player;
    private GameObject helmet, sword;
    private int itemChoice;

	// Use this for initialization
	void Start () {
        HideUI();
    }

    public void SetHelmet(Collision2D item)
    {

        helmet = item.gameObject;
        nameD.text = item.gameObject.GetComponent<Helmet_Script>().nameDesc;
        amount.text = item.gameObject.GetComponent<Helmet_Script>().cost.ToString();

        itemChoice = 1;
        DisplayUI();

    }
    public void SetSword(Collision2D item)
    {
        sword = item.gameObject;
        nameD.text = item.gameObject.GetComponent<Weapon_Manager>().nameDesc;
        amount.text = item.gameObject.GetComponent<Weapon_Manager>().cost.ToString();
        itemChoice = -1;
        DisplayUI();

    }
    public void DisplayUI()
    {
        nameD.gameObject.SetActive(true);
        amount.gameObject.SetActive(true);
        coin.gameObject.SetActive(true);
        if (itemChoice == 1)
        {

            if (player.GetComponent<Player_Manager>().ownedHelmets[helmet.GetComponent<Helmet_Script>().index])
            {
                equip.gameObject.SetActive(true);
                buy.gameObject.SetActive(false);
            }
            else
            {
                buy.gameObject.SetActive(true);
                equip.gameObject.SetActive(false);
            }

        }
        else if(itemChoice == -1)
        {
            if (player.GetComponent<Player_Manager>().ownedWeapons[sword.GetComponent<Weapon_Manager>().index])
            {
                equip.gameObject.SetActive(true);
                buy.gameObject.SetActive(false);
            }
            else
            {
                buy.gameObject.SetActive(true);
                equip.gameObject.SetActive(false);
            }

        }
    }
    public void HideUI()
    {
        nameD.gameObject.SetActive(false);
        amount.gameObject.SetActive(false);
        coin.gameObject.SetActive(false);
        equip.gameObject.SetActive(false);
        buy.gameObject.SetActive(false);
        
    }
    public void EquipWeapon()
    {
        if(player.GetComponent<Player_Manager>().currentWeapon != sword.GetComponent<Weapon_Manager>().index)
        {
            player.GetComponent<Player_Manager>().currentWeapon = sword.GetComponent<Weapon_Manager>().index;
            PlayerPrefs.SetInt("weapon", sword.GetComponent<Weapon_Manager>().index);
            player.GetComponent<Player_Manager>().SwitchWeapon();
        }
    }
    public void EquipHelmet()
    {
        if (player.GetComponent<Player_Manager>().currentArmor != helmet.GetComponent<Helmet_Script>().index)
        {
            player.GetComponent<Player_Manager>().currentArmor = helmet.GetComponent<Helmet_Script>().index;
            PlayerPrefs.SetInt("helmet", helmet.GetComponent<Helmet_Script>().index);
            player.GetComponent<Player_Manager>().SwitchHelmet();
        }
    }
    public void BuyWeapon()
    {
        if (PlayerPrefs.GetInt("coins") >= sword.GetComponent<Weapon_Manager>().cost)
        {
            player.GetComponent<Player_Manager>().ownedWeapons[sword.GetComponent<Weapon_Manager>().index] = true;

            BoolArray ownedWeapons = new BoolArray(player.GetComponent<Player_Manager>().ownedWeapons);
            PlayerPrefs.SetString("ownedWeapons", JsonUtility.ToJson(player.GetComponent<Player_Manager>().ownedWeapons));
            
            buy.gameObject.SetActive(false);
            equip.gameObject.SetActive(true);
            player.GetComponent<Player_Manager>().AddCoin(-1 * sword.GetComponent<Weapon_Manager>().cost);
        }
    }
    public void BuyHelmet()
    {
        if (PlayerPrefs.GetInt("coins") >= helmet.GetComponent<Helmet_Script>().cost)
        {
            player.GetComponent<Player_Manager>().ownedHelmets[helmet.GetComponent<Helmet_Script>().index] = true;

            BoolArray ownedHelmets = new BoolArray(player.GetComponent<Player_Manager>().ownedHelmets);
            PlayerPrefs.SetString("ownedHelmets", JsonUtility.ToJson(player.GetComponent<Player_Manager>().ownedHelmets));
            buy.gameObject.SetActive(false);
            equip.gameObject.SetActive(true);
            player.GetComponent<Player_Manager>().AddCoin(-1*helmet.GetComponent<Helmet_Script>().cost);
        }
    }
    public void Buy()
    {
        if (itemChoice == 1)
        {
            BuyHelmet();
        }
        else if (itemChoice == -1)
        {
            BuyWeapon();
        }
    }
    public void Equip()
    {
        if (itemChoice == 1)
        {
            EquipHelmet();
        }
        else if (itemChoice == -1)
        {
            EquipWeapon();
        }
    }
    [System.Serializable]
    public class BoolArray
    {
        public bool[] arr;

        public BoolArray(bool[] init)
        {
            this.arr = init;
        }
    }
}
