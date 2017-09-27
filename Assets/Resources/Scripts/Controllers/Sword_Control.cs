// Sword Control
// Controls sword movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Control : MonoBehaviour {
    private GameObject player;
    private GameObject inputManager;
    private int dir;
    private float startTime;
    public bool isSwing;

    void Start()
    {
        startTime = Time.time;
        inputManager = GameObject.Find("InputManager");
        player = GameObject.Find("Slime_Player");
        isSwing = false;
       
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Chest" && isSwing)
        {
            Debug.Log("Chest Hit");
            Destroy(other.gameObject);
            player.GetComponent<Player_Manager>().AddCoin(other.gameObject.GetComponent<Chest_Manager>().gold);


        }
        if(other.gameObject.tag == "Enemy")
        {
            // If weapon not in attack and Player attack is less than enemy level
            if (isSwing)
            {
                other.gameObject.GetComponent<Enemy_Manager>().health -= player.GetComponent<Player_Manager>().level + GetComponent<Weapon_Manager>().level;

                if (other.gameObject.GetComponent<Enemy_Manager>().health <= 0)
                {
                    Destroy(other.gameObject);
                    player.GetComponent<Player_Manager>().SetXp(other.gameObject.GetComponent<Enemy_Manager>().xp);
                }
                

            }
            else
            {
                Debug.Log("Enemy hit weapon");
                player.GetComponent<Player_Manager>().health -= other.gameObject.GetComponent<Enemy_Manager>().level;

            }
        }
        if (other.gameObject.tag == "Boss")
        {
            // If weapon not in attack and Player attack is less than enemy level
            if (isSwing)
            {
                other.gameObject.GetComponent<Enemy_Manager>().health -= player.GetComponent<Player_Manager>().level + GetComponent<Weapon_Manager>().level;

                if (other.gameObject.GetComponent<Enemy_Manager>().health <= 0)
                {
                    other.gameObject.SetActive(false);
                    player.GetComponent<Player_Manager>().SetXp(other.gameObject.GetComponent<Enemy_Manager>().xp);
                }


            }
            else
            {
                Debug.Log("Enemy hit weapon");
                player.GetComponent<Player_Manager>().health -= other.gameObject.GetComponent<Enemy_Manager>().level;

            }
        }
    }
    void Update()
    {
        dir = player.GetComponent<Player_Control>().direction;
        if(dir == 0)
        {
            dir = 1;
        }

        if (inputManager.GetComponent<Input_Manager>().CheckSwipe() == -1)
            Swing();
        if (Time.time - startTime > .3)
        {
            Reset();
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, dir * -400) * Time.deltaTime);
            transform.position = new Vector3(player.transform.position.x + (dir * .5f), player.transform.position.y, 0f);
        }

    }
    void Swing()
    {
        startTime = Time.time;
        isSwing = true;
        SwordState();
        // transform.rotation = Quaternion.Euler(0,0,-90);

    }
    void Reset()
    {
        SwordState();
        isSwing = false;
    }
    void SwordState()
    {
        transform.position = new Vector3(player.transform.position.x +(dir * .5f), player.transform.position.y, 0f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
   



}

















