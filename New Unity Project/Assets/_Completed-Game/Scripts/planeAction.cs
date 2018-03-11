using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoundaryY{
	public float yMin,yMax;
}

public class planeAction : MonoBehaviour {
	public GameObject camera;
	// Use this for initialization

	void Start () {
        //注册视角转换时的监听
        CameraSwitch.on2DCamera += new CameraSwitch.CameraChangeEventHandler(On2D);
        CameraSwitch.on3DCamera += new CameraSwitch.CameraChangeEventHandler(On3D);
    }
	
	// Update is called once per frame
	void Update () {
		if (!camera.GetComponent<Camera> ().enabled) {
			if (Input.GetKey(KeyCode.W))
			{
				transform.position += new Vector3(0,0.1f,0);
				//Debug.Log("EEE");
			}
			if (Input.GetKey(KeyCode.S))
			{
				transform.position -= new Vector3(0, 0.1f, 0);
			}
		}

	}

    public void On2D() {
        Debug.Log("Plane Resumed!");
        transform.Find("my_plane_test").GetComponent<MeshRenderer>().enabled = true;
    }

    public void On3D()
    {
        Debug.Log("Plane Vanished!");
        transform.Find("my_plane_test").GetComponent<MeshRenderer>().enabled = false;
    }


}
