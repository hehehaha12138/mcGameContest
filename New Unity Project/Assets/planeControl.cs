using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeControl : MonoBehaviour {
    private bool is3D = false;

	// Use this for initialization
	void Start () {
        MoveGalaxy.RotateEventHandler += new MoveGalaxy.TransformController(On3D);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (!is3D) {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.position += new Vector3(0.0f, -0.1f, 0.0f); 
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.transform.position += new Vector3(0.0f, 0.1f, 0.0f);
            }
        }   
    }

    void On3D(bool is3D) {
        this.is3D = is3D;
    }
}
