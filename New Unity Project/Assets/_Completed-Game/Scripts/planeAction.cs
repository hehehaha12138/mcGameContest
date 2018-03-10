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
		

}
