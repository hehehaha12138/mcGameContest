using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitJudgement : MonoBehaviour {
    private bool isExit = false;
    // Use this for initialization
    void Start () {
        NewBehaviourScript.openExit += new NewBehaviourScript.getCollectHandler(OpenExit);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("other.name");
        Debug.Log(isExit);
        if (isExit && other.name == "my_cube_test")
        {
            SceneManager.LoadScene("main_level_scene");

        }
    }

    void OpenExit()
    {
        isExit = true;
    }
}
