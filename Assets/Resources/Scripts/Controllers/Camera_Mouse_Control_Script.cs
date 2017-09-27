using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Camera_Mouse_Control_Script : MonoBehaviour {

    private Vector3 mouseVector;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(0))
        {
            offset = mouseVector;
            return;
        }

        if (Input.GetMouseButton(0))
        {
          
            GetComponent<Rigidbody2D>().velocity = -1 * (mouseVector - offset);
            
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            GetComponent<Camera>().orthographicSize += .2f;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            GetComponent<Camera>().orthographicSize -= .2f;
            


    }
    void OnGUI()
    {
        Vector2 mousePos = new Vector2();
        Camera c = Camera.main;
        Event e = Event.current;


        mousePos.x = e.mousePosition.x;
        mousePos.y = c.pixelHeight - e.mousePosition.y;

        mouseVector = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, c.nearClipPlane));
    }
}
