// Player Control
// Script for player behavior
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Control : MonoBehaviour {
	public float moveSpeed, jumpSpeed;
	public GameObject inputManager;
	private Rigidbody2D rb;
	private bool onGround;
    public bool isHome;
    public int direction;
	void Start(){
		rb = GetComponent<Rigidbody2D> ();

	}
    // Update is called once per frame
    void FixedUpdate() {

        float x = 0;
        // If click on screen and on the ground jump
        if ((inputManager.GetComponent<Input_Manager>().CheckSwipe() == 1 && onGround)) {

            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        if (Input.touchCount >= 1) { 
            if (Input.GetTouch(0).position.x < Screen.width / 2) {
                x = -1.0f;
                direction = -1;
            } else if (Input.GetTouch(0).position.x > Screen.width / 2) {
                x = 1.0f;
                direction = 1;
            } else {
                x = 0;
            }
    }
			

		
			
		rb.velocity = new Vector2 (moveSpeed*x, rb.velocity.y);
	}

		
	// On 2D collision 
	void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy")
        {

            if(transform.position.y > other.gameObject.transform.position.y + .4f)
            {
                onGround = true;
            }
            else
            {
                GetComponent<Player_Manager>().health -= other.gameObject.GetComponent<Enemy_Manager>().level;
            }

        }
        if (other.gameObject.tag == "Boss")
        {

            if (transform.position.y > other.gameObject.transform.position.y + .4f)
            {
                onGround = true;
            }
            else
            {
                GetComponent<Player_Manager>().health -= other.gameObject.GetComponent<Enemy_Manager>().level;
            }

        }
        // Set onGround true when player is touching the ground
        if (other.gameObject.tag == "Ground") {
			onGround = true;
		}
		// Add a coin to player and destroy coin
		if (other.gameObject.tag == "Coin") {
			gameObject.GetComponent<Player_Manager> ().AddCoin (1);
			Destroy (other.gameObject);	
		}
        if (isHome)
        {

            if (other.gameObject.tag == "Weapon" || other.gameObject.tag == "Helmet")
            {
                Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                GameObject temp = GameObject.Find("Home_Manager");
                if(other.gameObject.tag == "Helmet")
                    temp.GetComponent<Home_Manager_Script>().SetHelmet(other);
                else
                    temp.GetComponent<Home_Manager_Script>().SetSword(other);

            }


        }

	   }
	// When exit of 2D collsion
	void OnCollisionExit2D(Collision2D other){

		// Set onGround to false when jumping off the ground
		if (other.gameObject.tag == "Ground") 
			onGround = false;
        if (isHome)
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(),false);
        }

    }
		
}
