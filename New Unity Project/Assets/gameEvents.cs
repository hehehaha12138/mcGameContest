using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEvents : MonoBehaviour {
    public GameObject protagonist;
    public int initialLockFrame;

    private int frameCount;
    
	// Use this for initialization
	void Start () {
        frameCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //Lock Motion of Protagonist
        frameCount++;
        if (frameCount <= initialLockFrame)
        {
            protagonist.GetComponent<NewBehaviourScript>().isInit = true;
        }
        else {
            protagonist.GetComponent<NewBehaviourScript>().isInit = false;
        }
	}
}
