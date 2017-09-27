// Game Manager
// Handles game scene events

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

	public Transform tree;
	public Transform enemy;
	public Transform coin;
	public float spawnTreeTime, spawnEnemyTime, spawnCoinTime;

	void Start(){

		// At the start of scene Invoke these methods and repeat them
		InvokeRepeating ("SpawnTree", 0.0f, spawnTreeTime);
		InvokeRepeating ("SpawnTree", 1.5f, spawnTreeTime);

	


	}
	// Spawns a tree
	void SpawnTree(){
		Instantiate (tree, new Vector3 (20, .25f,1f),Quaternion.identity);
		tree.localScale = new Vector2 (Random.Range (.25f, 2f), Random.Range (1f, 2f));
	}
	// Spawns an enemy
	void SpawnEnemy(){

		Instantiate (enemy, new Vector3 (20, .25f,-1f),Quaternion.identity);
		enemy.localScale = new Vector2 (Random.Range (2f, 3f), Random.Range (1f, 2f));

	}
	// Spawns a coin
	void SpawnCoin(){
		Instantiate (coin, new Vector3 (20, -.6f,1f),Quaternion.identity);
	}
}
