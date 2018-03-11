using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CameraSwitch.on2DCamera += new CameraSwitch.CameraChangeEventHandler(On2D);
        CameraSwitch.on3DCamera += new CameraSwitch.CameraChangeEventHandler(On3D);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void On2D() {
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void On3D() {
        GetComponent<MeshRenderer>().enabled = true;
    }
}
