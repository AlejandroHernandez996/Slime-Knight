using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Control : MonoBehaviour {

    public float moveSpeed, jumpSpeed;
    public float attackDistance;
    public Rigidbody2D playerRb;
    private float dif;
    public float dir;
    public GameObject[] enemies;
    private int stage;
    private float health;
    private float startTime;
    private float duration;
    void Start()
    {
        startTime = 0;
        duration = 5;
        stage = 0;
        playerRb = GameObject.Find("Slime_Player").GetComponent<Rigidbody2D>() as Rigidbody2D;
    }

    [SerializeField]
    private Rigidbody2D rb;
    // Update is called once per frame
    void FixedUpdate()
    {


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
    void Update()
    {
        health = GetComponent<Enemy_Manager>().health;
        Debug.Log(stage);
        BossStages();
        if(stage > 0 && (startTime == 0 || Time.time-startTime > duration))
        {
            Spawn();
        }
        
    }
    void BossStages()
    {

        if(health < 100)
        {
            stage = 3;
        }
        else if(health < 300)
        {
            stage = 2;
        }
        else if(health < 400)
        {
            stage = 1;
        }
    }
    void Spawn()
    {
        startTime = Time.time;
        if (stage == 1)
        {
            Instantiate(enemies[0], new Vector2(transform.position.x - 3, transform.position.y+2), Quaternion.identity);
            Instantiate(enemies[1], new Vector2(transform.position.x + 3, transform.position.y+2), Quaternion.identity);
        }
        if (stage == 2)
        {
            Instantiate(enemies[2], new Vector2(transform.position.x - 3, transform.position.y+2), Quaternion.identity);
            Instantiate(enemies[3], new Vector2(transform.position.x + 3, transform.position.y+2), Quaternion.identity);
        }
        if (stage == 3)
        {
            Instantiate(enemies[4], new Vector2(transform.position.x - 3, transform.position.y+2), Quaternion.identity);
            Instantiate(enemies[5], new Vector2(transform.position.x + 3, transform.position.y+2), Quaternion.identity);
        }
    }
}
