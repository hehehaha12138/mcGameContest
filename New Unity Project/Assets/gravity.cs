using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour {
    private Dictionary<string, Collider> GravityInfluence;
    public GameObject Plane;
    public delegate void LandController(GameObject gameObject);
    public static event LandController LandEventHandler;
    public static event LandController LaunchEventHandler;

	// Use this for initialization
	void Start () {
        GravityInfluence = new Dictionary<string, Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        //Debug.Log("111");
        Vector3 scale = this.transform.parent.transform.localScale;
        Vector3 size = this.GetComponent<MeshFilter>().mesh.bounds.size;
        //Debug.Log(scale.x);
        foreach (KeyValuePair<string, Collider> kv in GravityInfluence) {
            //Debug.Log("force:"+this.name);
            Vector3 Destination = new Vector3(GetComponent<Transform>().position.x,Plane.GetComponent<Transform>().position.y,GetComponent<Transform>().position.z);
            Vector3 Direction = Mathf.Pow(scale.x,2)*4*(kv.Value.GetComponent<Transform>().position - Destination).normalized;
            double distance = (kv.Value.GetComponent<Transform>().position - Destination).magnitude;
            //Debug.Log(distance);
            //Debug.Log(size.x * scale.x / 2);
            if (distance - 0.15 < size.x * scale.x / 2)
            {
                //Debug.Log("Langding!!:" + this.name);
                LandEventHandler(this.transform.parent.gameObject);
            }
        
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

    private void OnTriggerExit(Collider other)
    {
        GravityInfluence.Remove(other.name);
        if (other.transform.name == "Cube") {
            LaunchEventHandler(this.transform.parent.gameObject);
        }
    }

    /*private void judgePosition(GameObject game) {
        Vector3 GamePosition = game.transform.position;
        double distance = (this.transform.position - GamePosition).magnitude;
        //double thres
        //if(distance > )
    }*/
}
