using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_UI_Motion : MonoBehaviour {
    public GameObject camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = camera.GetComponent<Rigidbody>().velocity;
    }
}
