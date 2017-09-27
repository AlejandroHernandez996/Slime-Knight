// Enemy_Manager
// Manages Enemy Stats
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour {

	public int xp;
    public int level;
    public int health;
    private int maxHealth;

    void Start()
    {
        maxHealth = health;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }

}
