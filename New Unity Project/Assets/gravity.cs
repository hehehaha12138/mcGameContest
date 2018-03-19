using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour {
    private Dictionary<string, Collider> GravityInfluence;
    public GameObject Plane;

	// Use this for initialization
	void Start () {
        GravityInfluence = new Dictionary<string, Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        foreach (KeyValuePair<string, Collider> kv in GravityInfluence) {
            //Debug.Log("force:"+kv.Value.name);
            Vector3 Destination = new Vector3(GetComponent<Transform>().position.x,Plane.GetComponent<Transform>().position.y,GetComponent<Transform>().position.z);
            Vector3 Direction = 4*(kv.Value.GetComponent<Transform>().position - Destination).normalized;
            double distance = (kv.Value.GetComponent<Transform>().position - Destination).magnitude;
            //Debug.Log(Destination.x);
            kv.Value.GetComponent<Rigidbody>().AddForce(-Direction/Mathf.Pow((float)distance,2));
            //Debug.Log("force over");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        GravityInfluence.Add(other.name,other);
    }
}
