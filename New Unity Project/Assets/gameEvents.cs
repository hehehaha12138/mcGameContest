using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameEvents : MonoBehaviour {
    public GameObject protagonist;
    public int initialLockFrame;

    //private int collectCount = 0;
    private int frameCount;
    private bool isExit = false;
    
	// Use this for initialization
	void Start () {
        frameCount = 0;
        NewBehaviourScript.openExit += new NewBehaviourScript.getCollectHandler(openExit);
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

    private void OnTriggerEnter(Collider other)
    {
        if (isExit&&other.name == "my_cube_test")
        {
            SceneManager.LoadScene("main_level_scene");
            
        }
    }

    void openExit() {
        isExit = true;
    }
    
}
