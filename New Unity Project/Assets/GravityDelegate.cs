using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityDelegate : MonoBehaviour {
    public delegate void GravityHandler(GameObject gameObject);
    public static event GravityHandler OnMove;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OnMove(this.gameObject);
	}
}
