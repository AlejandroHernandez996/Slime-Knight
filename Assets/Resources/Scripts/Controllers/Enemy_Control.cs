using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Control : MonoBehaviour {

	public float moveSpeed, jumpSpeed;
	public float attackDistance;
	public Rigidbody2D playerRb;
    private float dif;
    public float dir;
	void Start(){
		playerRb = GameObject.Find ("Slime_Player").GetComponent<Rigidbody2D>() as Rigidbody2D;
	}

	[SerializeField]
	private Rigidbody2D rb;
	// Update is called once per frame
	void FixedUpdate () {

        
        dif = playerRb.transform.position.x - rb.transform.position.x;

        dir = dif / Mathf.Abs(dif);

        if (inRange())
        {

            rb.velocity = new Vector2(moveSpeed * dir, rb.velocity.y);

        }
        
	}
    public bool inRange()
    {
        if (Mathf.Abs(dif) < attackDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
