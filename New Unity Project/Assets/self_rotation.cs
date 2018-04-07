using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class self_rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        this.transform.RotateAround(new Vector3(-21.15f, 0.0f, 0.804f),new Vector3(0f,0.5f,0f),1);
    }
}
