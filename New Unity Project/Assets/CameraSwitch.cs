using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

	public GameObject[] cameras;
	public string[] shotcuts;
	public Vector3 OriginPos;
	public Vector3 LeftPos;
	public GameObject camera;

	// Use this for initialization
	void Start () {
		cameras [0].GetComponent<Camera> ().enabled = true;
		cameras [1].GetComponent<Camera> ().enabled = false;
		cameras [2].GetComponent<Camera> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		for (i = 0; i < cameras.Length; i++) {
			if (Input.GetKeyUp (shotcuts [i]))
				SwitchCamera (i);
		}
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

	}
}
