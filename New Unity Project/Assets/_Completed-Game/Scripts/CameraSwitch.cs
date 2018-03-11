using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {
    //Change Camera Event
    public delegate void CameraChangeEventHandler();

    public static event CameraChangeEventHandler on2DCamera;
    public static event CameraChangeEventHandler on3DCamera;

    public GameObject plane;
    public GameObject[] obstacles;
	public GameObject[] cameras;
	public string[] shotcuts;
	public Vector3 OriginPos;
	public Vector3 LeftPos;
	public GameObject camera;
    public GameObject Protangonist;

	// Use this for initialization
	void Start () {
        

		cameras [0].GetComponent<Camera> ().enabled = true;
		cameras [1].GetComponent<Camera> ().enabled = false;

        //cameras [2].GetComponent<Camera> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		for (i = 0; i < cameras.Length; i++) {
			if (Input.GetKeyUp (shotcuts [i]))
				SwitchCamera (i);
		}
        GetSection();
	}

	void SwitchCamera(int index){
		/*Debug.Log (index);
		switch (index) {
		case 0:
			camera.GetComponent<Camera> ().transform.position = OriginPos;
			break;
		case 1:
			camera.GetComponent<Camera> ().transform.position = LeftPos;
			break;
		}*/
		int i = 0;
		for (i = 0; i < cameras.Length; i++) {
			if (i != index) {
				cameras [i].GetComponent<Camera> ().enabled = false; 
			} 
			else {
				cameras [i].GetComponent<Camera> ().enabled = true; 
			}
		}

        switch (i) {
            case 1:
                onSet2DCamera();
                break;
            case 2:
                onSet3DCamera();
                break;
            default:
                break;
        }

	}

    void onSet2DCamera() {

    }

    void onSet3DCamera() {

    }

    void GetSection() {
        for (int i = 0; i < obstacles.Length; i++) {
            Vector3 obstaclePosition = obstacles[i].GetComponent<Transform>().position;
            Vector3 planePosition = plane.GetComponent<Transform>().position;

            Mesh mesh = obstacles[i].GetComponent<MeshFilter>().mesh;
            Vector3 meshSize = mesh.bounds.size;
            Vector3 scale = transform.lossyScale;
            double r = meshSize.y * scale.y;

            /*SphereCollider cap = obstacles[i].GetComponent<SphereCollider>();
            double r = cap.radius;*/
            //Debug.Log(obstaclePosition);
            //Debug.Log(r);
            double smallR = System.Math.Pow(r,2)-System.Math.Pow(planePosition.y-obstaclePosition.y,2);
            //smallR = System.Math.Pow(smallR, 0.5);
            Debug.Log(smallR);
        }

    }
}
