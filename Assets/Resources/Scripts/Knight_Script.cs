using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Script : MonoBehaviour {
    public Transform sword;
    
	void Start()
    {
        sword = Instantiate(sword, new Vector2(transform.position.x + (GetComponent<Enemy_Control>().dir * 1), transform.position.y+.2f), Quaternion.identity);
    }
	// Update is called once per frame
	void FixedUpdate () {


        if (GetComponent<Enemy_Control>().inRange())
        {
            sword.transform.Rotate(new Vector3(0, 0, 1000) * Time.deltaTime);
            sword.transform.position = new Vector3(transform.position.x + (GetComponent<Enemy_Control>().dir*1), transform.position.y + .2f, 0f);
        }
        else
        {
            sword.transform.position = new Vector3(transform.position.x + (GetComponent<Enemy_Control>().dir * 1), transform.position.y + .2f, 0f);
        }
        if(GetComponent<Enemy_Manager>().health <= 0)
        {
            Destroy(sword.gameObject);
        }
    }

	
}
