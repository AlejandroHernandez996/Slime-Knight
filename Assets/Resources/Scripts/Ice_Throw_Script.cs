using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Throw_Script : MonoBehaviour {

    public Transform ball;

    public float moveSpeed, jumpSpeed;
    public float attackDistance;

    private Rigidbody2D playerRb;

    private float dif;
    public float dir;
    private float startTime;
    public float duration;

    void Start()
    {
        playerRb = GameObject.Find("Slime_Player").GetComponent<Rigidbody2D>() as Rigidbody2D;
    }


    void FixedUpdate()
    {

        if (Mathf.Abs(dif) < attackDistance/2)
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed *-1* dir, GetComponent<Rigidbody2D>().velocity.y);

        }

    }
    void Update()
    {
        dif = playerRb.transform.position.x - GetComponent<Rigidbody2D>().transform.position.x;

        dir = dif / Mathf.Abs(dif);
        if (Mathf.Abs(dif) < attackDistance && Time.time - startTime > duration)
        {
            startTime = Time.time;
            Instantiate(ball, new Vector2(transform.position.x + (dir * 1), transform.position.y), Quaternion.identity);
        }
    }
}
