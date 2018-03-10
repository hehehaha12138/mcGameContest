using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class trackCamera : MonoBehaviour {
    public GameObject UI;
    public GameObject protagonist;
    public float rightBoundary;
    public float leftBoundary;
    private Vector3 relative_coordination;
    public float acc;
    private bool isRight = true;
    private bool isLeft = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
      
    }

    void FixedUpdate()
    {
        float speed = protagonist.GetComponent<Rigidbody>().velocity.x;
        if (speed < 0)
        {
            isRight = true;
        }
        else {
            isRight = false;
        }
        Vector3 proPosition = protagonist.GetComponent<Rigidbody>().position;
        relative_coordination = GetComponent<Rigidbody>().position - proPosition;
        //Debug.Log(relative_coordination.x);

        //scroll right motion
        if (GetComponent<Transform>().position.x < rightBoundary && !isLeft) {
            Debug.Log("R" + GetComponent<Transform>().position.x);
            //Debug.Log("RIGHT BOUND");
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (isRight && relative_coordination.x > 0 && GetComponent<Rigidbody>().velocity.x > speed && speed < 0 )
        {
            if (isLeft) {
                GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                isLeft = false;
            }
            GetComponent<Rigidbody>().AddForce(new Vector3(speed / 2, 0.0f, 0.0f));
        }

        //scroll left motion
        if (GetComponent<Transform>().position.x > leftBoundary && isLeft) {
            //Debug.Log("L"+GetComponent<Transform>().position.x);
            //Debug.Log("LEFT BOUND");
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (!isRight && relative_coordination.x < 0 && GetComponent<Rigidbody>().velocity.x < speed && speed > 0) {
            if (!isLeft) {
                GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                isLeft = true;
            }
            GetComponent<Rigidbody>().AddForce(new Vector3(speed / 2, 0.0f, 0.0f));
        } 
        if (speed == 0 && relative_coordination.x < 0.1 && relative_coordination.x>-0.1) {
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f,0.0f,0.0f);
        }
        UI.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
    }
}
