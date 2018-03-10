using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_controller : MonoBehaviour {
	public GameObject objective_1;
	public GameObject objective_2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (objective_1 == null && objective_2 == null) {
			GetComponent<SphereCollider> ().enabled = false;
			GetComponent<MeshCollider> ().enabled = true;
		}
	}
}
