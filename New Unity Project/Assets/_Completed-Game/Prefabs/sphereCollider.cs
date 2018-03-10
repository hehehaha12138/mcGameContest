using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereCollider : MonoBehaviour {
	//public GameObject sphereTest;
	public Transform  OverlapSphereCube; 
	public float SearchRadius;
	// Use this for initialization
	void Start () {
		SearchNearUnits();
	}
	
	// Update is called once per frame
	void Update () {
		SearchNearUnits();
	}

	public void SearchNearUnits()
	{
		//OverlapSphereCube = sphereTest.transform;
		Collider[] colliders = Physics.OverlapSphere(OverlapSphereCube.position, SearchRadius);

		if(colliders.Length <= 0) return ;

		for (int i = 0; i < colliders.Length; i++) {
			colliders [i].enabled = true;
			//Vector3 vel =  colliders [i].gameObject.GetComponent<Rigidbody> ().velocity;
			//colliders [i].gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, vel.z);
		}
			
	}
}
