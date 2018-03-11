using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NewBehaviourScript.onMove += new NewBehaviourScript.moveEventHandler(OnFollow);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnFollow(Vector3 position) {
        transform.position = position + new Vector3(5.0f,0.0f,-2.0f);
    }
}
