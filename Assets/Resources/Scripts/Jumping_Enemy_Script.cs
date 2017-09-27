using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping_Enemy_Script : MonoBehaviour {

    public float moveSpeed, jumpSpeed;
    public float attackDistance;
    private Rigidbody2D playerRb;
    private float dif;
    public float dir;
    private bool onGround;
    void Start()
    {
        playerRb = GameObject.Find("Slime_Player").GetComponent<Rigidbody2D>() as Rigidbody2D;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        dif = playerRb.transform.position.x - GetComponent<Rigidbody2D>().transform.position.x;

        dir = dif / Mathf.Abs(dif);

        if (Mathf.Abs(dif) < attackDistance)
        {

            if(onGround)
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * dir, jumpSpeed);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * dir, GetComponent<Rigidbody2D>().velocity.y);
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        // Set onGround true when player is touching the ground
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {

        // Set onGround to false when jumping off the ground
        if (other.gameObject.tag == "Ground")
            onGround = false;

    }

}
