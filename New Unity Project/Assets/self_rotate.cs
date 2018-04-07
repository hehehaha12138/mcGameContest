using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class self_rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0, 0, 5));
    }
}
