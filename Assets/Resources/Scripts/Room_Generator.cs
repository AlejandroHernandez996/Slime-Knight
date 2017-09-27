using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Generator : MonoBehaviour {

	public Transform tile;
	public Transform wallTile;
	public Transform player;
	public Transform enemy;
    public Transform chest;
    public Transform enemy2;

	public int tileLength;
	public int startLength;
	public int endLength;
    public int chestAmount;

	public int maxPlatform;
	public int minPlatform;

    public int maxGold;

	private int currentHeight;

	private int index;

	private int tilesRemaining;
	private int upsRemaining;
	private int downsRemaining;

	private List<int> tileGroups = new List<int> ();
	private List<int> upDownList = new List<int> ();

	// Use this for initialization
	void Start () {

		// Set tiles remaining to max tiles
		tilesRemaining = tileLength;
		//Starting heigh is 0
		currentHeight = 0;

		// Add beginning tiles
		for (int x = 0; x < startLength; x++) {

			CreateTile (x);
			tilesRemaining--;
			index++;

		}
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 30; x++)
            {
                Instantiate(wallTile, new Vector2(-1-y, x - 10), Quaternion.identity);
                Instantiate(wallTile, new Vector2(y+tileLength, x - 10), Quaternion.identity);
            }
        }
		// Add end tiles
		for (int x = tileLength; x > tileLength-endLength; x--) {

			CreateTile (x-1);
			tilesRemaining--;


		}
		GroupTiles ();

		upsRemaining = tileGroups.Count / 2;
		downsRemaining = tileGroups.Count - upsRemaining;
		GenerateUpDowns ();
		GenerateTiles ();
		player.transform.position = new Vector2 (startLength / 2, 2);

	}
	
	void GroupTiles(){

		// 8 tiles
		// 2 1 2 1 
		while (tilesRemaining != 0) {

			int tempAmount = Random.Range (minPlatform, maxPlatform);
			// 1 
			if (tilesRemaining - tempAmount >= 0) {
				tileGroups.Add (tempAmount);
				tilesRemaining -= tempAmount;
			} else if (tilesRemaining - tempAmount < 0) {
				tileGroups.Add (tilesRemaining);
				tilesRemaining = 0;
			}

		}

	}

	void GenerateTiles(){

		int j = 0;
		foreach (int x in tileGroups) {
			currentHeight += upDownList [j];
			for (int y = 0; y < x; y++) {
				CreateTile (index);
				index++;
			}
			if (x > 5 && x < 8) {
				CreateEnemy (enemy, index - (x / 2));
                Debug.Log(x);
                Debug.Log(enemy.gameObject.name);
            }
            if (x > 3 && x < 6 && x != 4 && enemy2.gameObject.name == "Jumping_Enemy")
            {
                Debug.Log("Jumping Enemy");
                for (int y = 0; y < x; y++)
                {
                    CreateEnemy(enemy2, index - (x-y));
                }
            }
            if (x > 8 && enemy2.gameObject.name == "Giant_Ice_Enemy") 
            {
                Debug.Log(x);
                Debug.Log(enemy2.gameObject.name);
                CreateEnemy(enemy2, index - (x / 2));
            }
            if (x == 4 && chestAmount > 0)
            {
                CreateChest(index - (x / 2));
                chestAmount--;
            }
            if(x >  8 && enemy2.gameObject.name == "Super_Enemy_Slime")
            {
                CreateEnemy(enemy2, index - (x / 2));
            }
			j++;
		}

	}
	void GenerateUpDowns(){


		for (int x = 0; x < tileGroups.Count; x++) {


			int temp = Random.Range (0, 2);

			if (temp == 0 && downsRemaining != 0) {
				upDownList.Add (-1);
				downsRemaining--;
			} else if (temp == 1 && upsRemaining != 0) {
				upDownList.Add (1);
				upsRemaining--;
			}

			if (temp == 0 && downsRemaining == 0) {
				upDownList.Add (1);
				upsRemaining--;
			} else if (temp == 1 && upsRemaining == 0) {
				upDownList.Add (-1);
				downsRemaining--;
			}
				

		}

	}
	void CreateTile(int x){
		Instantiate (tile, new Vector2(x,currentHeight), Quaternion.identity);

		for (int y = 0; y < 10; y++) {
			Instantiate (wallTile, new Vector2(x,currentHeight-y-1), Quaternion.identity);
		}
	}
	void CreateEnemy(Transform e, float x){
		Instantiate (e, new Vector2 (x, currentHeight + 1), Quaternion.identity);
	}
    void CreateChest(float x)
    {
       var c = Instantiate(chest, new Vector2(x, currentHeight + 1), Quaternion.identity);
        c.GetComponent<Chest_Manager>().gold = Random.Range(1, maxGold + 1);
    }
}
