using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planePosition : MonoBehaviour {
    public delegate void MoveController(Vector3 position);
    public static event MoveController MoveEventHandler;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveEventHandler(this.transform.position);
	}
}
