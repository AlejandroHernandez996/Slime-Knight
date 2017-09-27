using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour {
    public float moveSpeed;
    public float duration;

    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time - startTime > duration)
            Destroy(gameObject);
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * moveSpeed;
        }
            
	}
}
